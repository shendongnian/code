	using (TextWriter textWriter = new StreamWriter(fileName){
		textWriter.WriteLine(bmp.Width + " " + bmp.Height);
		for (int x = 0; x < bmp.Width; x++)
		{
			for (int y = 0; y < bmp.Height; y++)
			{
				Color pixel = bmp.GetPixel(x, y);
				textWriter.Write(pixel.R + "," + pixel.G + "," + pixel.B + " ");
			}
		}
	}
