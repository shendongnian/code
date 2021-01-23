     public partial class MainWindow : Window
        {
    
            Point currentPoint = new Point();
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
            {
                if (e.ButtonState == MouseButtonState.Pressed)
                    currentPoint = e.GetPosition(this);
            }
    
            private void Canvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Line line = new Line();
                    // Create a diagonal linear gradient with four stops.   
                    LinearGradientBrush myLinearGradientBrush =
                        new LinearGradientBrush();
                    myLinearGradientBrush.StartPoint = new Point(0, 0);
                    myLinearGradientBrush.EndPoint = new Point(1, 1);
                    myLinearGradientBrush.GradientStops.Add(
                        new GradientStop(Colors.Yellow, 0.0));
                    myLinearGradientBrush.GradientStops.Add(
                        new GradientStop(Colors.Red, 0.25));
                    myLinearGradientBrush.GradientStops.Add(
                        new GradientStop(Colors.Blue, 0.75));
                    myLinearGradientBrush.GradientStops.Add(
                        new GradientStop(Colors.LimeGreen, 1.0));
                    line.Stroke = myLinearGradientBrush;
                    line.X1 = currentPoint.X;
                    line.Y1 = currentPoint.Y;
                    line.X2 = e.GetPosition(this).X;
                    line.Y2 = e.GetPosition(this).Y;
    
                    currentPoint = e.GetPosition(this);
    
                    paintSurface.Children.Add(line);
                }
            }
        }
