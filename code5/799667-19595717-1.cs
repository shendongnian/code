    public void GetLatestHeadline(Action<string> callback)
    {
        _apiClient.Retrieve(userState: callback);
    }
    private void Retrieve_Completed(object sender, RetrieveCompletedEventArgs args)
    {
        var callback = args.UserState as Action<string>;
        if (callback != null)
            callback(args.Result.Headline);
    }
