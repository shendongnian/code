    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        mainTxtBox.Text = await gethtml("URL");
    }
    
    public async Task<string> gethtml(string URL)
    {
        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL);
        WebResponse myResponse = await myRequest.GetResponseAsync();
        StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
        return sr.ReadToEnd();  
    }
