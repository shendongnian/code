        public static void BeginDownload()
        {
            var wc = new WebClient();
            wc.DownloadDataCompleted += DownloadComplete;
            wc.DownloadDataAsync(new Uri("http://www......"));
            ...
        }
        private static void DownloadComplete(object sender, DownloadDataCompletedEventArgs args)
        {
            using (var ms = new MemoryStream(args.Result))
            {
                Image image = Image.FromStream(ms);
                // At this point you have the image downloaded and available
            }
        }
