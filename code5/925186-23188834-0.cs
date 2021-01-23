    static void Main(string[] args)
    {
        using (WebClient myWebClient = new WebClient())
        {
            myWebClient.DownloadFileCompleted += DownloadCompleted;
            myWebClient.DownloadFileAsync(new Uri("http://soundcloud.com/dubstep/spag-heddy-the-master-vip/download"), @"e:\file.mp3");
        }
        Console.ReadLine();
    }
    public static void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
    {
        Console.WriteLine("Success");
    }
