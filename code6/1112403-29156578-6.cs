    static void Main(string[] args)
    {
    	var img = DownloadRemoteImageFile( // Put your url here );
    
    	Image original;
        using (var ms = new MemoryStream(img))
        {
            original = Image.FromStream(ms);
        }
    
    	var newHeight = 120;
    	var newWidth = ScaleWidth(original.Height, 120, original.Width);
    
    	using (var newPic = new Bitmap(newWidth, newHeight))
    	using (var gr = Graphics.FromImage(newPic))
    	{
    	    gr.DrawImage(original, 0, 0, newWidth, newHeight);
    		newPic.Save(@"C:\newImage1.jpg", ImageFormat.Jpeg);
    	}
    }
