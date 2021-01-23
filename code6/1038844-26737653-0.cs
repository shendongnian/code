    public MyPage() 
    {
        this.Loaded += PageLoaded;
    }
    
    void PageLoaded(object sender, RoutedEventArgs e)
    {
        this.Event();
    }
