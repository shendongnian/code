    //assume you have a class member variable of type bitmap called sourceBitmap.
    BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                        sourceBitmap.Width, sourceBitmap.Height),
                                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
    
    byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
    
    Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
    
    sourceBitmap.UnlockBits(sourceData);
    
    File.WriteAllBytes(@"C:\..\..\test.txt", pixelBuffer);
    
    //here is where you can split the code...
    byte[] fs = File.ReadAllBytes(@"C:\..\..\test.txt");
                
    Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
    
    BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                        resultBitmap.Width, resultBitmap.Height),
                                        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
    
    Marshal.Copy(fs, 0, resultData.Scan0, fs.Length);
                resultBitmap.UnlockBits(resultData);
    
    pictureBox1.Image = resultBitmap;
