    FileInfo file = new FileInfo(FD.FileName);
    int pixels = (int)file.Length / 3; // int must be enough (anyway limited by interfaces accepting only int)
    
    byte[] bytes = File.ReadAllBytes(file.FullName);
    if (file.Length % 3 != 0) {
        Array.Resize(ref bytes, 3 * pixels + 3);
    }
    
    Bitmap image = new Bitmap(pixels, 1);
    foreach (var x in Enumerable.Range(0, pixels)) {
        image.SetPixel(x, 0, Color.FromArgb(bytes[3*x] , bytes[3*x+1], bytes[3*x+2]));
    }
    image.Save("newfile.png", ImageFormat.Png);
