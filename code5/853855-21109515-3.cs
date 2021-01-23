            //This takes the byte[] array from the kinect and makes a bitmap from the colour data for us
            byte[] pixeldata = new byte[CF.PixelDataLength];
            CF.CopyPixelDataTo(pixeldata);
            System.Drawing.Bitmap bmap = new System.Drawing.Bitmap(CF.Width, CF.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            BitmapData bmapdata = bmap.LockBits(new System.Drawing.Rectangle(0, 0, CF.Width, CF.Height), ImageLockMode.WriteOnly, bmap.PixelFormat);
            IntPtr ptr = bmapdata.Scan0;
            Marshal.Copy(pixeldata, 0, ptr, CF.PixelDataLength);
            bmap.UnlockBits(bmapdata);
            //display our colour frame
            currentFrame = new Image<Bgr, Byte>(bmap);
            Image<Gray, Byte> skin2 = skinDetector.DetectSkin(currentFrame, YCrCb_min, YCrCb_max);
            ExtractContourAndHull(skin2);
            DrawAndComputeFingersNum();
            //Display our images using WPF Dispatcher Invoke as this is a sub thread.
            Dispatcher.BeginInvoke((Action)(() =>
                {
                    ColorImage.Source = BitmapSourceConvert.ToBitmapSource(currentFrame);
                }), System.Windows.Threading.DispatcherPriority.Render, null);
            Dispatcher.BeginInvoke((Action)(() =>
                {
                    SkinImage.Source = BitmapSourceConvert.ToBitmapSource(skin2);
                }), System.Windows.Threading.DispatcherPriority.Render, null);
