    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    namespace WpfDrawing
    {
        public partial class MainWindow : Window
        {
            private Point _p1;
            private Point _p2;
            private bool _painting;
            private readonly Pen _rectPen = new Pen(Brushes.Blue, 1);
            private readonly SolidColorBrush _rectBrush = new SolidColorBrush
            {
                Color = Colors.SkyBlue
            };
            public MainWindow()
            {
                InitializeComponent();
                //--workaround: set the background as transparent.
                Background = Brushes.Transparent;
                //--Freeze the painting objects to increase performance.
                _rectPen.Freeze();
                _rectBrush.Freeze();
            }
            protected override void OnRender(DrawingContext drawingContext)
            {
                var rect = new Rect(_p1, _p2);
                Debug.WriteLine("OnRender -> " + rect);
                //--set background in white
                Rect backRect = new Rect(0, 0, ActualWidth, ActualHeight);
                drawingContext.DrawRectangle(Brushes.White, null, backRect);
                //--draw the rectangle
                drawingContext.DrawRectangle(_rectBrush, _rectPen, rect);
            }
            private void MainWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                var p = e.GetPosition(this);
                Debug.WriteLine("MainWindow_OnMouseLeftButtonDown -> " + p);
                _p1 = _p2 = p;
                _painting = true;
                InvalidateVisual();
            }
            private void MainWindow_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                _painting = false;
                Debug.WriteLine("MainWindow_OnMouseLeftButtonUp");
            }
            private void MainWindow_OnMouseMove(object sender, MouseEventArgs e)
            {
                if (!_painting)
                    return;
                var p = e.GetPosition(this);
                Debug.WriteLine("MainWindow_OnMouseMove -> " + p);
                _p2 = p;
                InvalidateVisual();
            }
        }
    }
