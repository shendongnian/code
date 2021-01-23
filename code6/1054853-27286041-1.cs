    bool isfirstitem = true;
        public MainPage()
        {
            InitializeComponent();
        }
        private void itemgrid_Tap(object sender, GestureEventArgs e)
        {
            if (isfirstitem)
            {
                itemtext.Text = "˅";
                list.Visibility = Visibility.Visible;
            }
            else
            {
                itemtext.Text = "˄";
                list.Visibility = Visibility.Collapsed;
            }
            isfirstitem=!isfirstitem;
            
        }
