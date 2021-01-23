    private void Post(string YourUsername, string Password)
    {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("User", YourUsername);
            parameters.Add("Password", Password);
            PostClient proxy = new PostClient(parameters);
            proxy.DownloadStringCompleted += proxy_UploadDownloadStringCompleted;
            
            proxy.DownloadStringAsync(new Uri("http://mytestserver.com/Test.php",UriKind.Absolute));
            
    } 
    private void proxy_UploadDownloadStringCompleted(object sender,WindowsPhonePostClient.DownloadStringCompletedEventArgs e)
    {
        if (e.Error == null)
            MessageBox.Show(e.Result.ToString());
    }     
            
        
