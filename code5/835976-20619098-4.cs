    public class ExtendedCustomMessageBox : CustomMessageBox
    {
        public Brush TitleForeground
        {
            get { return (Brush)GetValue(TitleForegroundProperty); }
            set { SetValue(TitleForegroundProperty, value); }
        }
        public static readonly DependencyProperty TitleForegroundProperty =
            DependencyProperty.Register("TitleForeground", typeof(Brush), typeof(ExtendedCustomMessageBox), null);
        public CustomMessage()
            : base()
        {
            DefaultStyleKey = typeof(CustomMessageBox);
        }
    }
