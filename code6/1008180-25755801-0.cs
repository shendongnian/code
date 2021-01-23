    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    void DrawBitmapGreyscale(DrawingContext dc, string filename, int x, int y, int width, int height)
    {
    	// Load the bitmap into a bitmap image object
    	BitmapImage bitmap = new BitmapImage();
    	bitmap.BeginInit();
    	bitmap.CacheOption = BitmapCacheOption.OnLoad;
    	bitmap.UriSource = new Uri(filename);
    	bitmap.EndInit();
    
    	// Convert the bitmap to greyscale, and draw it.
    	FormatConvertedBitmap bitmapGreyscale = new FormatConvertedBitmap(bitmap, PixelFormats.Gray8, BitmapPalettes.Gray256, 0.0);
    	dc.DrawImage(bitmapGreyscale, new Rect(x, y, width, height));
    }
