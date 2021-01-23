    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    namespace So21501609WpfMouseRenderTransform
    {
        public partial class MainWindow
        {
            private GeneralTransform _transform;
            public MainWindow ()
            {
                InitializeComponent();
                Loaded += OnLoaded;
            }
            private void OnLoaded (object sender, RoutedEventArgs routedEventArgs)
            {
                var origin = new Point(lstItems.ActualWidth / 2, lstItems.ActualHeight / 2);
                var transform = ((TransformGroup)Resources["CanvasTransform"]).Clone();
                transform.Children.Insert(0, new TranslateTransform(-origin.X, -origin.Y));
                transform.Children.Add(new TranslateTransform(origin.X, origin.Y));
                _transform = transform.Inverse;
            }
            private void LstItems_OnMouseDown (object sender, MouseButtonEventArgs e)
            {
                Point pos = _transform.Transform(e.GetPosition(lstItems));
                var item = new TextBlock { Text = pos.ToString() };
                Canvas.SetLeft(item, pos.X);
                Canvas.SetTop(item, pos.Y);
                lstItems.Items.Add(item);
            }
        }
    }
