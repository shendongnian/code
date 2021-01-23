            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = container;
            using (response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            {
                // All of this code is unnecessary if using .NET 4.0 or higher.
                /*
                byte[] buffer = new byte[10000000];
                int read, total = 0;
                while ((read = stream.Read(buffer, total, 1000)) != 0)
                {
                    total += read;
                }
                MemoryStream ms = new MemoryStream(buffer, 0, total);
                ms.Seek(0, SeekOrigin.Current);
                */
                // Instead use the following
                MemoryStream ms = new MemoryStream();
                stream.CopyTo(ms);
                Bitmap bmp = (Bitmap)Bitmap.FromStream(ms);
                pictureBoxTabTwo.Image = bmp;
                this.pictureBoxTabTwo.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxTabTwo.Image.Save("FormTwo.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
