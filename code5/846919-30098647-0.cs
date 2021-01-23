     void PDFToImage(MemoryStream inputMS, int dpi)
        {
            GhostscriptRasterizer rasterizer = null;
            GhostscriptVersionInfo version = new GhostscriptVersionInfo(
                                                                    new Version(0, 0, 0), @"C:\PathToDll\gsdll32.dll", 
                                                                    string.Empty, GhostscriptLicense.GPL);
            using (rasterizer = new GhostscriptRasterizer())
            {
                rasterizer.Open(inputMS, version, false);
                for (int i = 1; i <= rasterizer.PageCount; i++)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        DrawImage img = rasterizer.GetPage(dpi, dpi, i);
                        img.Save(ms, ImageFormat.Jpeg);
                        ms.Close();
                        AspImage newPage = new AspImage();
                        newPage.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((byte[])ms.ToArray());
                        Document1Image.Controls.Add(newPage);
                    }
                }
                rasterizer.Close();
            }
        }
