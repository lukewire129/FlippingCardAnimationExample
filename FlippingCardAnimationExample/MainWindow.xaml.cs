using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace FlippingCardAnimationExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent ();
        }
        private bool isFlip = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            isFlip = !isFlip;

            if (isFlip)
            {
                FrontAnimation ();
                return;
            }
            BackAnimation ();
        }
        public void FrontAnimation()
        {
            backCard.Visibility = Visibility.Hidden;
            frontCard.Visibility = Visibility.Visible;

            DoubleAnimation flipDoubleAnimation = new DoubleAnimation (-1, 1, TimeSpan.FromMilliseconds (1000));
            flipDoubleAnimation.EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut };

            var scale = new ScaleTransform ();
            frontCard.RenderTransform = scale;
            scale.BeginAnimation (ScaleTransform.ScaleXProperty, flipDoubleAnimation);
        }
        public void BackAnimation()
        {
            frontCard.Visibility = Visibility.Hidden;
            backCard.Visibility = Visibility.Visible;

            DoubleAnimation flipDoubleAnimation = new DoubleAnimation (-1, 1, TimeSpan.FromMilliseconds (1000));
            flipDoubleAnimation.EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut };

            var scale = new ScaleTransform ();
            backCard.RenderTransform = scale;
            scale.BeginAnimation (ScaleTransform.ScaleXProperty, flipDoubleAnimation);
        }
    }
}
