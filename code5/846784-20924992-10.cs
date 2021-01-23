    public MainPage()
            {
                InitializeComponent();
                ServiceReference1.Services1Client webservice = new Services1Client();
                webservice.GetListCompleted += new EventHandler<GetListCompletedEventArgs>(webservice_GetListCompleted);
    
                webservice.GetListAsync();
               
            }
    
    
            public void webservice_GetListCompleted(object sender, ServiceReference1.GetListCompletedEventArgs e)
            {
                //Attached the data to the DataGrid in silverlight
                DataGridImages.ItemsSource = e.Result;
            }
