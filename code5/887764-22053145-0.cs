    public ViewModel()
    {
        Messenger.Default.Register<NotificationMessage<Exception>>(this, message =>
            {
                // Handle here
            });
    
        Task.Factory.StartNew(() => FetchData());
    }
    
    public async Task FetchData()
    {
    	// Some magic happens here
        try
        {
            Thread.Sleep(2000);
            throw new ArgumentException();
        }
        catch (Exception e)
        {
            Messenger.Default.Send(new NotificationMessage<Exception>(this, e, "Aw snap!"));
        }
    }
