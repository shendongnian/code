    if (File.Exists(pathFromYourImage) // Just to check if path is valid
    {
        PictureBox pb1 = new PictureBox();
        pb1.Image = System.Drawing.Image.FromFile(pathFromYourImage);
    }
