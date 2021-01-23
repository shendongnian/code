    public MainPage()
    {
            InitializeComponent();
            FindMe();
    }
    private void Bingtask()
    {
        BingMapsTask bingMap = new BingMapsTask();
        bingMap.SearchTerm = txtsearch.Text; 
        bingMap.ZoomLevel = 10;
        bingMap.Show();
    }
        private void FindMe()
        {
            tblcurpos1.Text = "Not Found";
        }
 
       private void btnsearch_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
       {
            Bingtask();
       }
