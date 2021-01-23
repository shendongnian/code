    private Image<Gray, Byte> newImage(Image<Gray, Byte> image1, Image<Gray, Byte> image2)
    {
        int ImageWidth = 0;
        int ImageHeight = 0;
    //get max width
        if (image1.Width > image2.Width)
            ImageWidth = image1.Width;
        else
            ImageWidth = image2.Width;
    //calculate new height
        ImageHeight = image1.Height + image2.Height;
    //declare new image (large image).
        Image<Gray, Byte> imageResult;
        Bitmap bitmap = new Bitmap(Math.Max(image1.Width , image2.Width), image1.Height + image2.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(image1.Bitmap, 0, 0);
                g.DrawImage(image2.Bitmap, 0, image1.Height);
            }
            imageResult = new Image<Gray, byte>(bitmap);
        return imageResult;
    }
