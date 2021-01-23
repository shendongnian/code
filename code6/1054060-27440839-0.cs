    public class Pair : DependencyObject
    {
        public static readonly DependencyProperty FirstProperty = DependencyProperty.Register("First",
            typeof(object), typeof(Pair), new PropertyMetadata(null));
        public static readonly DependencyProperty SecondProperty = DependencyProperty.Register("Second",
            typeof(object), typeof(Pair), new PropertyMetadata(null));
        public object First
        {
            get { return GetValue(FirstProperty); }
            set { SetValue(FirstProperty, value); }
        }
        public object Second
        {
            get { return GetValue(SecondProperty); }
            set { SetValue(SecondProperty, value); }
        }
    }
