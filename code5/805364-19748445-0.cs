    PictureBox overlay = new PictureBox();
    overlay.Dock = DockStyle.Fill;
    overlay.BackColor = Color.Transparent;
    Bitmap transparentImage = new Bitmap(overlayImage.Width, overlayImage.Height);
    using (Graphics graphics = Graphics.FromImage(transparentImage))
    {
        ColorMatrix matrix = new ColorMatrix();
        matrix.Matrix33 = 0.5f;
        ImageAttributes attributes = new ImageAttributes();
        attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        graphics.DrawImage(overlayImage, new Rectangle(0, 0, transparentImage.Width, transparentImage.Height), 0, 0, overlayImage.Width, overlayImage.Height, GraphicsUnit.Pixel, attributes);
    }
    overlay.Image = transparentImage;
    pictureBox2.Controls.Add(overlay);
