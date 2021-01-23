    static void TestImage(ThermalPrinter printer)
		{
			printer.WriteLine("Test image:");
			Bitmap img = new Bitmap("../../../mono-logo.png");
			printer.LineFeed();
			printer.PrintImage(img);
			printer.LineFeed();
			printer.WriteLine("Image OK");
		}
