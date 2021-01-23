      public partial class GraphControl : UserControl
      {
        public IEnumerable<double> Data
        {
          get { return (IEnumerable<double>)GetValue(DataProperty); }
          set { SetValue(DataProperty, value); }
        }
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(IEnumerable<double>), typeof(GraphControl), new PropertyMetadata(null, OnDataChanged));
    
        private static void OnDataChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
          var control = (GraphControl)dependencyObject;
          control.HandleDataChanged();
        }
    
        public Brush Color
        {
          get { return (Brush)GetValue(ColorProperty); }
          set { SetValue(ColorProperty, value); }
        }
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Brush), typeof(GraphControl), new PropertyMetadata(Brushes.Green));
    
        public double Maximum
        {
          get { return (double)GetValue(MaximumProperty); }
          set { SetValue(MaximumProperty, value); }
        }
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(GraphControl), new PropertyMetadata(100.0));
    
        private void HandleDataChanged()
        {
          var points = new PointCollection();
          double x = 0;
    
    
          points.Add(new Point(0, canvas.ActualHeight));
    
    
          var xScale = canvas.ActualWidth / (Data.Count() -1);
          var yScale = canvas.ActualHeight / Maximum;
          foreach (var dataPoint in Data)
          {
            var y = canvas.ActualHeight - dataPoint * yScale;
    
            points.Add(new Point(x,y));
            x += xScale;
    
          }
    
          points.Add(new Point(canvas.ActualWidth, canvas.ActualHeight));
    
          var fill = Color.Clone();
          fill.Opacity = 0.2;
          polygon.Stroke = Color;
          polygon.Fill = fill;
    
          polygon.Points = points;
    
        }
    
        Polygon polygon = new Polygon() ;
    
        public GraphControl()
        {
          InitializeComponent();
    
          var fill = Color.Clone();
          fill.Opacity = 0.2;
          polygon.Stroke = Color;
          polygon.Fill = fill;
    
          polygon.StrokeThickness = 1;
    
          canvas.Children.Add(polygon);
        }
      }
