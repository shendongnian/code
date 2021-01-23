    byte[] bytes = null;
    using (System.Drawing.Image image = new Bitmap(w, h))
    {
    	using (Graphics g = Graphics.FromImage(image))
    	{
    		g.DrawImage(originalImage, 0, 0, w, h);
    		using (MemoryStream ms = new MemoryStream())
    		{
    			image.Save(ms, ImageFormat.Png);
    			bytes = ms.ToArray();
    		}
    	}
    }
    return bytes;
