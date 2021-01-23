                        if (!System.IO.File.Exists(pathString))
                    {
                        System.Windows.Media.PixelFormat pf = System.Windows.Media.PixelFormats.Gray16;
                        int stride = newImage.imageWidth * 2;
                        BitmapPalette pallet = BitmapPalettes.Gray16;
                        double dpix = 216;
                        double dpiy = 163;
                        BitmapSource bmpSource = BitmapSource.Create(imageWidth, imageHeight, dpix, dpiy, pf, pallet, intArray, stride);
                        using (FileStream fs = new FileStream(pathString, FileMode.Create))
                        {
                            TiffBitmapEncoder encoder = new TiffBitmapEncoder();
                            encoder.Compression = TiffCompressOption.None;
                            encoder.Frames.Add(BitmapFrame.Create(bmpSource));
                            encoder.Save(fs);
                        }
                        
                    }
