    public SenastePage()
    {
        // Write the XAML of your page to display the loading animation per default
        InitializeComponent();
    
        Task.Factory.StartNew(LoadData);
    }
        
    private void LoadData()
    {
        ((ManualResetEvent)PhoneApplicationService.Current.State["manualResetEvent"]).WaitOne();
    
        Dispatcher.BeginInvoke(() =>
        {
            SenasteArticleList.ItemsSource = ((ArticleList)PhoneApplicationService.Current.State["articleList"]).posts;
            // Hide the loading animation
        }
    }
