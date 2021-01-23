    public class MyGrid : Control
    {
        public static readonly DependencyProperty LeftProperty = DependencyProperty.Register("Left", typeof(object), typeof(MyGrid), new PropertyMetadata(null));
        public object Left
        {
            get { return (object)GetValue(LeftProperty); }
            set { SetValue(LeftProperty, value); }
        }
    
        public static readonly DependencyProperty RightProperty = DependencyProperty.Register("Right", typeof(object), typeof(MyGrid), new PropertyMetadata(null));
        public object Right
        {
            get { return (object)GetValue(RightProperty); }
            set { SetValue(RightProperty, value); }
        }
    
        static MyGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyGrid), new FrameworkPropertyMetadata(typeof(MyGrid)));
        }
    }
