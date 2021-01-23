    public string fileurl;
    public string filetitle;
    public string filesave;
    private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        ...
        foreach (XElement rssItem in elements)
        {
            ...
            TextBlock tbLink = new TextBlock();
            tbLink.Text = "Download: " + rss.Link1; 
            //Add the link info to tbLink, you can get the info when tbLink is Clicked
            tbLink.Tag = new string[] {rss.Link1, rss.Description1};
            tbLink.MouseLeftButtonDown += new MouseButtonEventHandler(tbLink_MouseLeftButtonDown);
            ListBoxRss.Items.Add(tbLink);
        }
    }
    private void tbLink_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {       
       //get the link info from tbLink's Tag property
       string[] linkInfo = (sender as TextBlock).Tag as string[];
       fileurl = linkInfo[0];
       WebClient client = new WebClient();
       client.OpenReadCompleted += client_OpenReadCompleted;
       //pass the link info to the OpenReadCompleted callback
       client.OpenReadAsync(new Uri(fileurl), linkInfo);         
    }
    async void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        //and you get the link info from the e.UserState property
        string[] linkInfo = e.UserState as string[];
        filetitle = linkInfo[1];
        filesave = (filetitle + ".zip");
        ...
    }
