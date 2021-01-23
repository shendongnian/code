    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    namespace WpfApplication
    {
        public partial class MainWindow : Window
        {
            private UIElement _lastClickedUIElement;
            private Point? _clickOffset;
    
            public MainWindow() { InitializeComponent(); }
    
            private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                _lastClickedUIElement = sender as UIElement;
                _clickOffset = e.GetPosition(_lastClickedUIElement);
            }
    
            private void Ellipse_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                _lastClickedUIElement = null;
            }
    
            private void Any_MouseMove(object sender, MouseEventArgs e)
            {
                if (_lastClickedUIElement == null)
                    return;
    
                _lastClickedUIElement.SetValue(Canvas.LeftProperty, e.GetPosition(this).X - _clickOffset.Value.X);
                _lastClickedUIElement.SetValue(Canvas.TopProperty, e.GetPosition(this).Y - _clickOffset.Value.Y);
            }
        }
    }
