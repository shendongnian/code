	try
	{	        
		var image = Image.FromFile("d:\\temp\\image.jpg");
		using (var graphics = Graphics.FromImage(image))
		{
			var font = new Font(FontFamily.GenericSansSerif, 16.0f);
			graphics.DrawString("copyright 2014", font, Brushes.Red, new Point(10, 10));
		}
		image.Save("d:\\temp\\image_copyright.jpg");
	}
	catch (Exception exception)
	{
		Console.WriteLine(exception.Message);
	}
