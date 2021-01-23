    NetworkStream ns = client.GetStream();
                Graphics g = Graphics.FromImage(bitmap);
                MemoryStream imageStream = new MemoryStream();
                using (var ms = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(bitmap);
                    bmp.Save(imageStream, ImageFormat.Bmp);
                }
                                        
                
               // bitmap.Save(imageStream, ImageFormat.Bmp);
                Console.WriteLine("Bild wird über Socket geschickt");
                //reset the memory stream to start of stream
                imageStream.Position = 0;
                //copy memory stream to network stream
                imageStream.CopyTo(ns);
                //make sure copy is completed
                imageStream.Flush();
                imageStream.Close();
                //Makes sure everything is sent before closing it
                ns.Flush();   
