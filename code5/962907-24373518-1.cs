    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty yAxis2Property =
            DependencyProperty.Register("yAxis2", typeof(string), typeof(MainWindow));
        public string yAxis2
        {
            get { return (string)GetValue(yAxis2Property); }
            set { SetValue(yAxis2Property, value); }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.yAxis2 = "TESTING";
        }
