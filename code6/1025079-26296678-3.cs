    public partial class Page2 : Page
    {
        int valueFromPage1;
        public Page2()
        {
            InitializeComponent();
        }
        public Page2(int val):this()
        {
            valueFromPage1 = val;
            this.Loaded += new RoutedEventHandler(Page2_Loaded);
    
        }
        void Page2_Loaded(object sender, RoutedEventArgs e)
        {
            lbl.Content = "Value passed from page1 is: " + valueFromPage1;
        }
    }
