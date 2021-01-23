    public void makeTransPix(int steps)
    {
        using (Bitmap bmp = new Bitmap(  imageList1.Images[1] )  ) 
        {
            for (int t = 0; t < steps; t++)
            {
                Bitmap tBmp = new Bitmap(bmp.Width, bmp.Height);
                using (var g = Graphics.FromImage(tBmp))
                {
                    Rectangle R = new Rectangle(0, 0, bmp.Width, bmp.Height);
                    using (var brush = new SolidBrush(button1.BackColor))
                            g.FillRectangle(brush, R);
                    var colorMatrix = new ColorMatrix();
                    colorMatrix.Matrix33 = t / (float)steps;
                    var imageAttributes = new ImageAttributes();
                    imageAttributes.SetColorMatrix(
                        colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    g.DrawImage(bmp, R, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, imageAttributes);
                }
                imageList1.Images.Add(tBmp);
            }
        }
    }
