    // Path to source file
    string inputPath = Server.MapPath(@"~\Content\somefile.jpg");
    
    // Create an image from the file
    using (Image img = Bitmap.FromFile(inputPath))
    {
        // Rotate the image 90 degrees
        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
        // Path to destination file
        string outputPath = Server.MapPath(@"~\Content\rotated" +
            System.IO.Path.GetExtension(inputPath));
        // Delete the destination file if it already exists
        if (System.IO.File.Exists(outputPath))
        {
            System.IO.File.Delete(outputPath);
        }
        // Save the rotated image in the same ImageFormat as the source
        img.Save(outputPath, img.RawFormat);
    }
