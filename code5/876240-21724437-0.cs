    public static async void DoDownload() 
    {
         var uri = new Uri("example.org");
         Console.WriteLine(await Extensions.DownloadStringAsync(uri));            
    }
