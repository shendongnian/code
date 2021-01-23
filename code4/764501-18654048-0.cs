                byte[] imagedata = dt.Rows[0]["Data"] as byte[];
            System.Drawing.Image newImage;
            if (imagedata != null)
            {
                using (MemoryStream stream = new MemoryStream(imagedata))
                {
                    newImage = System.Drawing.Image.FromStream(stream);
                    newImage.Save("C:\\Users\\User\\Documents\\TestPictureConversion\\WebApplication2\\WebApplication2\\Images\\Test Image.png");
                }
            }
