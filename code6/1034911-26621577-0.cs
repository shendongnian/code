    public partial class MainPage : PhoneApplicationPage
    {
        // our simple download manager
        List<KeyValuePair<string, string>> DownloadManager = new List<KeyValuePair<string, string>>();
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // create our list of websites to download
            List<string> lstRSSFeeds = new List<string>();
            // lets add 3 web sites
            lstRSSFeeds.Add("http://www.google.com");
            lstRSSFeeds.Add("http://www.msn.com");
            lstRSSFeeds.Add("http://www.chubosaurus.com");
            // for each website in the list, download its data
            foreach (string rssFeed in lstRSSFeeds)
            {
                // our web downloader
                WebClient downloader = new WebClient();
                // our web address to download, notice the UriKind.Absolute
                Uri uri = new Uri(rssFeed, UriKind.Absolute);
                downloader.BaseAddress = uri.ToString();
                // we need to wait for the file to download completely, so lets hook the DownloadComplete Event
                downloader.DownloadStringCompleted += new DownloadStringCompletedEventHandler(FileDownloadComplete);
                // start the download
                downloader.DownloadStringAsync(uri);
            }
        }
        // this event will fire if the download was successful
        // we will save all the data to the DownloadManager
        void FileDownloadComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            // error check
            if (!e.Cancelled && e.Error == null)
            {
                 string uri = ((WebClient)sender).BaseAddress;   // set the key to the base address (url)
                 string html = e.Result;                         // save the html 
    
                 // create the KeyValuePair (this will save all the html and be indexed by the url)
                 KeyValuePair<string, string> site_data = new KeyValuePair<string, string>(uri, html);
    
                 // add the KeyValuePair to our download manager
                 DownloadManager.Add(site_data);
            }            
        }
    }
