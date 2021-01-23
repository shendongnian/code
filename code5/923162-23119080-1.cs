    public async Task DoRequestAsync() 
    {
        try 
        {
            var content = await new WebClient()
                .DownloadStringTaskAsync("address");
        }
        catch (WebException ex)
        {
          throw new WebException(String.Format("My special additional message {0}", ex.Message);
        }
    }
