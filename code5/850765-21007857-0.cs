	public static void TestProcessBitmap(string inputFile, string outputFile)
	{
		Bitmap bitmap = new Bitmap(inputFile);
		Bitmap formatted = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
		byte[] pixels = BitmapToPixelArray(formatted);
		pixels = Process8Bits(pixels, System.Windows.Media.Colors.Red);
		using (MemoryStream ms = new MemoryStream(pixels))
        {
            Bitmap output = (Bitmap)Image.FromStream(ms);
        }
	}
