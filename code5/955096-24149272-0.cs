    for (int i = 0; i < 2; i++)
                {
                    using (var image = System.Drawing.Image.FromFile(Image_URLs[i]))
                    {
                        GEncoder.AddFrame(image);
                        
                    }
                }
 
