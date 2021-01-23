    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Calling DoDownload");
            var downloadTask = DoDownloadAsync();
            Debug.WriteLine("DoDownload done");
            downloadTask.Wait(); //Waits for the background task to complete before finishing. 
        }
        private static async Task DoDownloadAsync()
        {
            WebClient w = new WebClient();
            string txt = await w.DownloadStringTaskAsync("http://www.google.com/");
            Debug.WriteLine(txt);
        }
    }
