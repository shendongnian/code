    foreach (string filePath in Directory.GetFiles(tifPath, "*.tif", SearchOption.AllDirectories))
    {
        using (var image = System.Drawing.Image.FromFile(filePath))
        {
            image.Save(jpgPath + "\\" + Path.GetFileNameWithoutExtension(filePath) + ".jpg", ImageFormat.Jpeg);
        }
    }
