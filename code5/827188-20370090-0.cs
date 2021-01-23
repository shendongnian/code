    using System.Net;
    class Program
    {
        public static void Main(string[] args)
        {
            using (WebRequest req = new WebRequest())
            {
                string downloadedChangelog = req.DownloadStringAsync(new Uri("http://www.site.com/changelog.txt"));
                changelogLabel.Text = downloadedChangelog;      
            }
        }
    }
