    public class CustomLabel : Label
    {
        public bool ApplyStyle
        {
            get { return (bool)GetValue(ApplyStyleProperty); }
            set { SetValue(ApplyStyleProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ApplyStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ApplyStyleProperty =
            DependencyProperty.Register("ApplyStyle", typeof(bool), typeof(CustomLabel), new PropertyMetadata(false));
    }
