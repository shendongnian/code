    var filename = @"C:\image.png";
    var url = @"http://www.somedomain.com/image.png";
    
    using (var client = new System.Net.WebClient())
    {
        client.DownloadFile(url, filename);
    }
    
    using (var image = System.Drawing.Image.FromFile(filename))
    {
        // Do something with image.
    }
