            BitmapDecoder decoder;
            using (Stream appendToOutput = File.Open(files[0], FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                decoder = BitmapDecoder.Create(appendToOutput, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None);
                using (Stream output = File.Open(outputFile, FileMode.Create, FileAccess.Write))
                {
                    TiffBitmapEncoder childEncoder = new TiffBitmapEncoder();
                    if(Path.GetExtension(files[0]).Replace(".", "") == ScanningImageFormat.Jpeg) {
                        childEncoder.Compression = TiffCompressOption.Zip;
                    } else {
                        childEncoder.Compression = TiffCompressOption.Ccitt4;
                    }
                    foreach (BitmapFrame frm in decoder.Frames)
                    {
                        childEncoder.Frames.Add(frm);
                    }
                    List<Stream> imageStreams = new List<Stream>();
                    try
                    {
                        for (int i = 1; i < files.Count; i++)
                        {
                            string sFile = files[i];
                            BitmapFrame bmp = null;
                            Stream original = File.Open(sFile, FileMode.Open, FileAccess.Read);
                            imageStreams.Add(original);
                            bmp = BitmapFrame.Create(original, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None);
                            childEncoder.Frames.Add(bmp);
                        }
                        childEncoder.Save(output);
                    }
                    finally
                    {
                        try
                        {
                            foreach (Stream s in imageStreams)
                            {
                                s.Close();
                            }
                        }
                        catch { }
                    }
                }
            }
            decoder = null;
