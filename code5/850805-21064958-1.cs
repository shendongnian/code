            //set the temporary file paths
            string tempPath = Path.GetTempPath();
            string tempFile = tempPath + @"tmpFile.png";
            //get the bounding box and reference point for the ink strokes (in inkspace coordinates!)
            Rectangle inkBox = inkPicture1.Ink.GetBoundingBox();
            Point point = new Point(inkBox.Left, inkBox.Top);
            MessageBox.Show(point.X.ToString() + ", " + point.Y.ToString());//"before" coordinates
            // Convert inkspace coordinates to pixel coordinates using Renderer
            Graphics tempGraphics = CreateGraphics();
            Microsoft.Ink.Renderer inkRenderer = new Renderer();
            inkRenderer.InkSpaceToPixel(tempGraphics, ref point);;
            MessageBox.Show(point.X.ToString() + ", " + point.Y.ToString());//"after" coordinates
            // Clean up
            tempGraphics.Dispose();
            
            // save the ink and background image to a temp file
            if (inkPicture1.Ink.Strokes.Count > 0)
            {
                byte[] bytes = inkPicture1.Ink.Save(PersistenceFormat.Gif, CompressionMode.NoCompression);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    using (Bitmap gif = new Bitmap(ms))
                    using (var bmp = new Bitmap(inkPicture1.BackgroundImage))
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(gif, new Rectangle(point.X, point.Y, gif.Width, gif.Height));
                        bmp.Save(tempFile, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }
