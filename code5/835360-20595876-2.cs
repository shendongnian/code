    public void GetUrls()
    {
        for (int i = 0; i < 5; i++)
        {
            Urls.Add(new Url { link = i.ToString() });
            App.Current.Dispatcher.Invoke((Action)(() => { }),
                                                   DispatcherPriority.Render);
        }
    }
