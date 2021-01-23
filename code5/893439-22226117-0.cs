    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        await gethtml("URL");
    }
    
    public async Task gethtml(string URL)
    {
        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL);
        WebResponse myResponse = await myRequest.GetResponseAsync();
        StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
        mainTxtBox.Text = sr.ReadToEnd();  
    }
