    public partial class SubCtrl : UserControl
    {
        public event EventHandler ButtonDoSomethingClicked;
        public string CounterLabelText
        {
            get { return (string)GetValue(CounterLabelTextProperty); }
            set { SetValue(CounterLabelTextProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CounterLabelText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CounterLabelTextProperty =
            DependencyProperty.Register("CounterLabelText", typeof(string), typeof(SubCtrl), new PropertyMetadata(null));
        public SubCtrl(int id)
        {
            InitializeComponent();
            CounterLabelText = id.ToString();
            DataContext = this;
            ButtonDoSomething.Click += ButtonDoSomething_Click;
        }
        void ButtonDoSomething_Click(object sender, RoutedEventArgs e)
        {
            ButtonDoSomethingClicked.Invoke(this, EventArgs.Empty);
        }
    }
