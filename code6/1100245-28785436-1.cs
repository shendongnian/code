                if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            else
            {
                //create a new empty bitmap to hold rotated image
                Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
                rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                //make a graphics object from the empty bitmap
                Graphics g = Graphics.FromImage(rotatedBmp);
                //move rotation point to center of image
                g.TranslateTransform((float)image.Width / 2, (float)image.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)image.Width / 2, -(float)image.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(image, new PointF(0, 0));
                return rotatedBmp;
            }
