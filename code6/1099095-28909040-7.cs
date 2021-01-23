    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
       
            private void FullImage_OnMouseDown(object sender, MouseButtonEventArgs e)
            {
                MagnifiyingTip.Visibility = Visibility.Visible;
                FullImage_OnMouseMove(sender, e);
            }
            private void FullImage_OnMouseMove(object sender, MouseEventArgs e)
            {
                if (MagnifiyingTip.Visibility == Visibility.Visible)
                {
                    MagnifiyingTip.Visibility = Visibility.Visible;
                    var pos = e.GetPosition(FullImage);
                    Canvas.SetLeft(MagnifiyingTip, pos.X - MagnifiyingTip.ActualWidth/2);
                    Canvas.SetTop(MagnifiyingTip, pos.Y - MagnifiyingTip.ActualHeight);
                    MagnifiyingTip.SetPosition(pos);
                }
            }
            private void FullImage_OnMouseUp(object sender, MouseButtonEventArgs e)
            {
                MagnifiyingTip.Visibility = Visibility.Hidden;
            }
        }
    }
