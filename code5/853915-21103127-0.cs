    public static void DownloadStringInBackground2 (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);
        // Specify that the DownloadStringCallback2 method gets called 
        // when the download completes.
        client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(
    DownloadStringCallback2);
        client.DownloadStringAsync (uri);
    }
    private static void DownloadStringCallback2 (Object sender, 
    DownloadStringCompletedEventArgs e)
    {
        // If the request was not canceled and did not throw 
        // an exception, display the resource. 
        if (!e.Cancelled && e.Error == null)
        {
            string textString = (string)e.Result;
            Console.WriteLine (textString);
        }
    }
