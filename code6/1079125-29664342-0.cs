        public static void GenerateEmbeddedIconPart(OpenXmlPart part, string filePath)
        {
            Byte[] image = GetIconBytes(filePath);
            using (var writer = new BinaryWriter(part.GetStream()))
            {
                writer.Write(image);
                writer.Flush();
            }
        }
        public static Byte[] GetIconBytes(string filePath)
        {
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(150, 60);
            bitmap.MakeTransparent();
            System.Drawing.Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(filePath);
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 8);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            string drawText = Path.GetFileName(filePath);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
            graphics.Clear(System.Drawing.Color.White);
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            graphics.DrawIcon(icon, 20, 0);
            graphics.DrawString(drawText, drawFont, drawBrush, 0, 48);                      
            
            Byte[] data;
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                data = memoryStream.ToArray();
            }
            drawFont.Dispose();
            drawBrush.Dispose();
            graphics.Dispose();
            return data;
        }
