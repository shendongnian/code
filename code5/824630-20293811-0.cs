    	using (var canvas = Graphics.FromImage(bitmap))
    	{
    		canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
    		//Draw each image (maybe use a loop to loop over images to draw)
                canvas.DrawImage(someImage, new Rectangle(0, 0, width, height), new Rectangle(0, 0, Frame.Width, Frame.Height), GraphicsUnit.Pixel);
    		canvas.Save();
    	}
