    public partial class ExampleUserControl : UserControl
    {
        public static readonly DependencyProperty SomeTextProperty =
            DependencyProperty.Register("SomeText", typeof(string), typeof(ExampleUserControl), new PropertyMetadata("default value"));
        public string SomeText
        {
            get { return (string)GetValue(SomeTextProperty); }
            set { SetValue(SomeTextProperty, value); }
        }
        // this is the same old stuff
        public ExampleUserControl()
        {
            InitializeComponent();
        }
    }
