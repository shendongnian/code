                Stream imageStreamSource = new FileStream("largeImage.jpg", FileMode.Open, FileAccess.Read, FileShare.Read);               
                JpegBitmapDecoder decoder = new JpegBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                BitmapSource bitmapSource = decoder.Frames[0];
                System.Windows.Controls.Image myImage = new System.Windows.Controls.Image();
                myImage.Source = bitmapSource;
