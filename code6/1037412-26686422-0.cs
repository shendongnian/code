    public partial class UpdownButton : Button
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(UpdownButton));
        public UpdownButton()
        {
            InitializeComponent();
        }
        public string Text
        {
            get { return GetValue(TextProperty) as string; }
            set { SetValue(TextProperty, value); }
        }
    }
