        public void DownloadFiles(IEnumerable<string> urls, string path)
        {
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
            System.Threading.Tasks.Parallel.ForEach(urls, url =>
            {
                using (var downloader = new  WebClient())
                {
                    var filePath = System.IO.Path.Combine(path, System.IO.Path.GetFileName(url));
                    downloader.DownloadFile(url,filePath);   
                }
            });
        }
