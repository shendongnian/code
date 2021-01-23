    Panel.DrawToBitmap(Bitmap, Panel.ClientRectangle);
    Bitmap bmp; //this will be the image where you would draw to
    Graphics g; // the graphics
    public ALANA_PAINT()
    {
        //do your stuff
        bmp = new Bitmap(Width,Height)// Initialize the bitmap
        Panel.BackgroundImage = bmp;
        g = Graphics.FromImage(bmp);
    }
    //your normal drawing methods
    public void Save()
    {
       bmp.Save(path,imageFormat);
    }
