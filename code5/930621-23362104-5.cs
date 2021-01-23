    private void btnLoadTiff_Click(object sender, EventArgs e)
    {
        List<Image> images = ..... // this collection contains all the images in TIFF
        // find the total width and height of all images in TIFF (this is because I will be showing images side by side
        int maxWidth = 0;
        int maxHeight = 0;
        foreach(Image img in images)
        {
            maxWidth += img.Width;
 
            if(maxHeight < img.Height)
                maxHeight = img.Height;
        }
        // if any image has height less then the other image, there will be blank spaces.
        // create new bitmap of the maxWidth and maxHeight (this bmp will have all the images drawn on itself
        Bitmap bmp = new Bitmap(maxWidth, maxHeight);
        Graphics g = Graphics.FromImage(bmp);
        // stores the x location where next image should be drawn
        int x = 0;
        foreach(Image img in images)
        {
             Rectangle rectSrc = new Rectange(0, 0, img.Width, img.Height);
             Rectangle rectDest = new Rectangle(x, 0, img.Width, img.Height);
             g.DrawImage(bmp, rectDest, rectSrc, GraphicsUnit.Pixel);
             x += img.Width;
        }
        // show the image in picturebox. The picturebox can have different stretch settings, or may be contained inside a panel with scrolling set.
        pictureBox1.Image = bmp;
    }
