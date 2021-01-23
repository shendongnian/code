    public sealed partial class YourUserControl: UserControl
    {
        public static readonly DependencyProperty myValueProperty = DependencyProperty.Register("myValue", typeof(string), typeof(YourUserControl), new PropertyMetadata(string.Empty));
        public YourUserControl()
        {
            this.InitializeComponent();
        }
        public string myValue
        {
            get { return (string)GetValue(myValueProperty ); }
            set { SetValue(myValueProperty , value); }
        }
    }
