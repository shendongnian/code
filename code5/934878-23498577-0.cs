    foreach(string file in files)
    {
        PictureBox pic = new PictureBox() { Image = Image.FromFile(file).resizeImage(50,50) };
        this.Controls.Add(pic);
    }
    public static Image resizeImage(this Image imgToResize, Size size)
    {
       return (Image)(new Bitmap(imgToResize, size));
    }
