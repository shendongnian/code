    class Downloader
    {
        internal WebClient Client { get; set; }
        internal Downloader() {
            WebClient client = new WebClient();
            Client = client;
        }
        internal void DownloadFile( string uri, string path ) {
            using ( Client ) {
                Client.DownloadFileAsync( new Uri(uri), path );
            }
        }
    }
