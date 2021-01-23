    var filePaths = Directory.GetFiles(@"C:\Users\ahaycraft\Desktop\TestImages",
                                        "*", SearchOption.AllDirectories);
    foreach (var path in filePaths)
    {
        using (var bmp = (Bitmap)Image.FromFile(path))
        {
           // ...
        }
    }
