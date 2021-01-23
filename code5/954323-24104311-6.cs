    class LineData : DependencyObject
    {
        public Point P1
        {
            get { return (Point)GetValue(P1Property); }
            set { SetValue(P1Property, value); }
        }
        // Using a DependencyProperty as the backing store for P1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty P1Property =
            DependencyProperty.Register("P1", typeof(Point), typeof(LineData), new PropertyMetadata(new Point(), (d, e) => (d as LineData).Update()));
        public Point P2
        {
            get { return (Point)GetValue(P2Property); }
            set { SetValue(P2Property, value); }
        }
        // Using a DependencyProperty as the backing store for P1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty P2Property =
            DependencyProperty.Register("P2", typeof(Point), typeof(LineData), new PropertyMetadata(new Point(), (d, e) => (d as LineData).Update()));
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(LineData), new PropertyMetadata(string.Empty));
        public double Length
        {
            get { return (double)GetValue(LengthProperty); }
            set { SetValue(LengthProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Length.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LengthProperty =
            DependencyProperty.Register("Length", typeof(double), typeof(LineData), new PropertyMetadata(0.0));
        public double TransformAngle
        {
            get { return (double)GetValue(TransformAngleProperty); }
            set { SetValue(TransformAngleProperty, value); }
        }
        // Using a DependencyProperty as the backing store for TransformAngle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TransformAngleProperty =
            DependencyProperty.Register("TransformAngle", typeof(double), typeof(LineData), new PropertyMetadata(0.0));
        public void Update()
        {
            //calculate angle
            double dy = P2.Y - P1.Y;
            double dx = P2.X - P1.X;
            double theta = Math.Atan2(dy, dx);
            theta *= 180 / Math.PI;
            TransformAngle = theta - 90;
            //calculate length
            double aSq = Math.Pow(P1.X - P2.X, 2); 
            double bSq = Math.Pow(P1.Y - P2.Y, 2);
            Length = Math.Sqrt(aSq + bSq);
        }
    }
