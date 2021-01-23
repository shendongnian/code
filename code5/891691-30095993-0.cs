    	public void WriteTextInPngFile(string filename, string description, string otherText)
	{
		Stream pngStream = new System.IO.FileStream(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
		PngBitmapDecoder pngDecoder = new PngBitmapDecoder(pngStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
		BitmapFrame pngFrame = pngDecoder.Frames[0];
		InPlaceBitmapMetadataWriter pngInplace = pngFrame.CreateInPlaceBitmapMetadataWriter();
		if (pngInplace.TrySave() == true)
		{ 
			pngInplace.SetQuery("/Text/Description", description); 
			pngInplace.SetQuery("/Text/YourField", otherText); 
		}
		pngStream.Close();
	}
