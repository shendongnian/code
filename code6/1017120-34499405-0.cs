    void Main()
	{
		TextRender();
	}
	
	public void TextRender()
	{
		//If you use a transparent color here, you won't see the text
		var imageBackgroundColor = new MagickColor("White");
		
		using (MagickImage image = new MagickImage(imageBackgroundColor, 400, 400))
		{
			var drawable = new DrawableText(0,10,"Line One\nLine Two\nLine Three");
			var gravity = new DrawableGravity(Gravity.North);
			var font = new DrawableFont("Arial");
			var antialias = new DrawableTextAntialias(true);
			var size = new DrawablePointSize(50);
			var color = new DrawableFillColor(Color.Black);
            //If needed
            //var strokeColor = new DrawableStrokeColor(Color.White);
	
			image.Annotate("Some annotation", Gravity.Center);
			
			image.Draw(drawable, gravity, font, antialias, size, color);//, strokeColor);
				
			var imageFileName = @"c:\temp\tempImage.jpg";
				
			//Write the file to disk
			image.Write(imageFileName);
			
			//For use in linqpad only
			//Load the written file from disk and show it in the Results window
			var image2 = (Bitmap) Image.FromFile(imageFileName, true);
			image2.Dump();
		}
	}
