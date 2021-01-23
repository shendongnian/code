    using(System.Drawing.Image image = System.Drawing.Image.FromFile(fullPath))
    {
        compressImage(destinationPath, image, 40);
    }
    System.IO.File.Delete(fullPath);
