    Parallel.ForEach(images, img =>
                                         {
                                             byte[] byteArray = new byte[0];
                                             using (MemoryStream stream = new MemoryStream())
                                             {
                                                 img.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                                                 stream.Close();
                                                 byteArray = stream.ToArray();
                                             }
                                         });
