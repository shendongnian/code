    public class MyGroupBox : GroupBox
    {
        public static readonly DependencyProperty CurrentWidthProperty =
            DependencyProperty.Register("CurrentWidth", typeof(double),
            typeof(MyGroupBox), new FrameworkPropertyMetadata(0d));
        public double CurrentWidth
        {
            get { return this.ActualWidth; }
            set { SetValue(CurrentWidthProperty, value); }
        }
    }
