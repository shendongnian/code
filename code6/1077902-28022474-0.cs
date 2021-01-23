       GrabHandler frameCallbackDelegate;
        void frameCallBack(IntPtr lpUserData, ref VCECLB_FrameInfoEx frameInfo)
        {
            if (frameInfo.dma_status != 0) return;
            // fill image
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            BitmapData bmdata = image.LockBits(rect, ImageLockMode.ReadWrite, image.PixelFormat);
            UInt32 outputBitDepth;
            IntPtr stride = new IntPtr(bmdata.Stride);
            VCECLB_Error err = NativeFunctions.VCECLB_UnpackRawPixelsEx(ref pRawPixelInfo, frameInfo.lpRawBuffer, bmdata.Scan0, ref stride, VCECLB_Output_Format.VCECLB_EX_FMT_TopDown | VCECLB_Output_Format.VCECLB_EX_FMT_3Channel, out outputBitDepth);
            image.UnlockBits(bmdata);
            // Convert bitmap to WPF-Image
            var bmp = new Bitmap(image);
            var hBitmap = bmp.GetHbitmap();
            ImageSource wpfBitmap =
                System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                            hBitmap,
                            IntPtr.Zero,
                            Int32Rect.Empty,
                            BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(hBitmap);
            image.Dispose();
            Dispatcher.Invoke(new Action(() =>
            {
                image_LowLight.Source = wpfBitmap;
            }));
            GC.Collect();
        }
