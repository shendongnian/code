    private Image LoadImage()
    {
        OpenFileDialog openFile = new OpenFileDialog();
        openFile.ShowDialog();
        byte[] byteImage = File.ReadAllBytes(openFile.FileName);
        Image myImage;
        using (var ms = new MemoryStream(byteImage))
        {
            myImage = Image.FromStream(ms);
        }
        return myImage;
     }
    private void SaveImage(Image myImage)
    {
        Bitmap bmp = new Bitmap(myImage);        
        // Temp save location
        bmp.Save("c:\\test\\myImage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
    }
