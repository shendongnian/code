    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MyUserControl), 
            new PropertyMetadata(new PropertyChangedCallback(OnTextChanged)));
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var myControl = d as MyUserControl;
            if (null != myControl)
            {
               var newValue = e.NewValue as string;
               if (null != newValue)
               {
                    var split = newValue.Split(':');
                    myControl.Text1 = split[0];
                    myControl.Text2 = split[1];
               }
            }
        }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
    }
