    static void Main(string[] args)
    {
    	WebClient client = new WebClient();
    	client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
    
    	string fileName = Path.GetTempFileName();
    	client.DownloadFileAsync(new Uri("https://www.google.com/images/srpr/logo11w.png"), fileName, fileName);
    
    	Thread.Sleep(20000);
    	Console.WriteLine("Done");
    }
    
    private static void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
    {
    	if (e.Error != null)
    	{
                // inspect error message for 404
    		Console.WriteLine(e.Error.Message);
    		if (e.Error.InnerException != null)
    			Console.WriteLine(e.Error.InnerException.Message);
    	}
    	else
    	{
    		// We have a file - do something with it
    		WebClient client = (WebClient)sender;
    
    		// display the response header so we can learn
    		foreach(string k in client.ResponseHeaders.AllKeys)
    		{
    			Console.Write(k);
    			Console.WriteLine(": {0}", client.ResponseHeaders[k]);
    		}
    
    		// since we know it's a png, let rename it
    		FileInfo temp = new FileInfo((string)e.UserState);
    		string pngFileName = Path.Combine(Path.GetTempPath(), "DesktopPhoto.png");
    		if (File.Exists(pngFileName))
    			File.Delete(pngFileName);
    
    		File.Move((string)e.UserState, pngFileName);  // move to where ever you want
    		Process.Start(pngFileName);
    	}
    
    }
