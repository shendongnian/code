            Bitmap bmPhoto = new Bitmap(Width, Height);
            bmPhoto.SetResolution(Resolution, Resolution);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);
            Matrix matrix = new Matrix();
            String watermarkText = "For office use only";
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            matrix.Translate(bmPhoto.Width / 2, bmPhoto.Height / 2);
            matrix.Rotate(-40.0f);// as per requirement we can give angle
            grPhoto.Transform = matrix;
            Font font = new Font("Verdana", 36, FontStyle.Bold, GraphicsUnit.Pixel);
            Color color = Color.FromArgb(100, 0, 0, 0); //Adds a transparent watermark with an 100 alpha value.
            SolidBrush sbrush = new SolidBrush(color);
            
            grPhoto.DrawString(watermarkText, font, new SolidBrush(color),0, 0,stringFormat);
