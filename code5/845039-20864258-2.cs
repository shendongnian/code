    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Calling DoDownload");
            DoDownloadAsync().Wait(); //Waits for the background task to complete. 
            Debug.WriteLine("DoDownload done");
        }
        private static async Task DoDownloadAsync()
        {
            WebClient w = new WebClient();
            string txt = await w.DownloadStringTaskAsync("http://www.google.com/");
            Debug.WriteLine(txt);
        }
    }
