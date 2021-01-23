        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap xImage = new Bitmap(@"PATH TO IMAGE");
            Size xImageSize = xImage.Size;
            int Skew = 30;
            using (Bitmap xNewImage = new Bitmap(120, 120)) //Determine your size
            {
                using (Graphics xGraphics = Graphics.FromImage(xNewImage))
                {
                    Point[] xPointsA =
                    {
                        new Point(0, Skew), //Upper Left
                        new Point(xImageSize.Width, 0), //Upper Right
                        new Point(0, xImageSize.Height + Skew) //Lower left
                    };
                    Point[] xPointsB =
                    {
                        new Point(xImageSize.Width, 0), //Upper Left
                        new Point(xImageSize.Width*2, Skew), //Upper Right
                        new Point(xImageSize.Width, xImageSize.Height) //Lower left
                    };
                    Point[] xPointsC =
                    {
                        new Point(xImageSize.Width, xImageSize.Height), //Upper Left
                        new Point(xImageSize.Width*2, xImageSize.Height + Skew), //Upper Right
                        new Point(0, xImageSize.Height + Skew) //Lower left
                    };
                    //Draw to new Image
                    xGraphics.DrawImage(xImage, xPointsA);
                    xGraphics.DrawImage(xImage, xPointsB);
                    xGraphics.DrawImage(xImage, xPointsC);
                }
                e.Graphics.DrawImage(xNewImage, new Point()); //Here you would want to assign the new image to the picture box
            }
        }
