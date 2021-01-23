    public void Client(string uri)
    {
        var clientToken = new WebClient();
        clientToken.OpenReadCompleted += clientToken_OpenReadCompleted;
        clientToken.OpenReadAsync(new Uri(uri));
    }
    
    private void clientToken_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        if (e.Error == null)
        {
           Stream reply = e.Result;
           StreamReader reader = new StreamReader(reply);
    
           MessageBox.Show(reader.ReadToEnd());
        }
    }
