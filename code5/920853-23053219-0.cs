     public MainPage()
            {
                InitializeComponent();
    
                SetBinding();
    
            }
    
            void SetBinding()
            {
                List<string> list = new List<string>();
                list.Add("January");
                list.Add("February");
                list.Add("March");
                list.Add("April");
                list.Add("May");
                list.Add("June");
                list.Add("July");
                list.Add("August");
                list.Add("September");
                list.Add("October");
                list.Add("November");
                list.Add("December");
                monthCat.ItemsSource = list;
            }
