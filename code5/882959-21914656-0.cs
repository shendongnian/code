    DirectoryInfo dirInfo = new DirectoryInfo(path);
    foreach ( FileInfo fileInfo in dirInfo.EnumerateFile() ) {
        ProcessImage(FileInfo.FullName);
    }
    void ProcessImage( string image ) {
        byte[] imageData = null;
        try {
            // Load the data in the file into a  byte array for processing.
            imageData = File.ReadAllBytes( image );
        } catch ( Exception) {
            // Your error handling code here
        }
        // We're going to put the image into this object
        BitmapImage src = new BitmapImage();
        try {
            // Load the image into a memory stream, then into src.
            using( MemoryStream stream = new MemoryStream( imageData ) ) {
                src.BeginInit();
                src.CacheOption = BitmapCacheOption.OnLoad; // Causes the bitmap data to be loaded now, not at a later time.
                src.StreamSource = stream;
                src.EndInit();
            }
        } catch ( NotSupportedException ) {
            // The bitmap format is not supported.  Your error handler here.
        }
        try {
            // Create a FormatConvertedBitmap object & set it up.
            FormatConvertedBitmap dst = new FormatConvertedBitmap();
            dst.BeginInit();
            dst.DestinationFormat = PixelFormats.Gray8;  // Use whatever gray scale format you need here
            dst.Source            = src;
            // Now convert the image to 8 bits per pixel grey scale.
            dst.EndInit();
            // Compute the dst Bitmap's stride (the length of one row of pixels in bytes).
            int stride = ( ( dst.PixelWidth * dst.Format.BitsPerPixel + 31 ) / 32 ) * 4;
            // Allocate space for the imageBytes array.
            imageBytes = new byte[ stride * dst.PixelHeight ];
            // Get the pixels out of the dst image and put them into imageBytes.
            dst.CopyPixels( Int32Rect.Empty, imageBytes, stride, 0 );
        } catch ( Exception ex ) {
            // Your error handler here.
        }
        // Any other code to save or do something else with the image.
    }
