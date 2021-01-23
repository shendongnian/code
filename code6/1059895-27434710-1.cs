    public void SaveBitmap(string location)
    {
        Bitmap bmp = new Bitmap((int)myPanel.Width, (int)myPanel.Height);
        DrawToBitmap(bmp, new Rectangle(0, 0, myPanel.Width, myPanel.Height));
        using (FileStream saveStream = new FileStream(location + ".bmp", FileMode.OpenOrCreate))
        {
            bmp.Save(saveStream, ImageFormat.Bmp);
        }                       
    }
