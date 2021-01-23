    public static class ImageHelper
        {
            /// <summary>
            /// ImageSource to bytes
            /// </summary>
            /// <param name="encoder"></param>
            /// <param name="imageSource"></param>
            /// <returns></returns>
            public static byte[] ImageSourceToBytes(BitmapEncoder encoder, ImageSource imageSource)
            {
                byte[] bytes = null;
                var bitmapSource = imageSource as BitmapSource;
    
                if (bitmapSource != null)
                {
                    encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
    
                    using (var stream = new MemoryStream())
                    {
                        encoder.Save(stream);
                        bytes = stream.ToArray();
                    }
                }
    
                return bytes;
            }
    
            [DllImport("gdi32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool DeleteObject(IntPtr value);
    
            public static BitmapSource GetImageStream(Image myImage)
            {
                var bitmap = new Bitmap(myImage);
                IntPtr bmpPt = bitmap.GetHbitmap();
                BitmapSource bitmapSource =
                 System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                       bmpPt,
                       IntPtr.Zero,
                       Int32Rect.Empty,
                       BitmapSizeOptions.FromEmptyOptions());
    
                //freeze bitmapSource and clear memory to avoid memory leaks
                bitmapSource.Freeze();
                DeleteObject(bmpPt);
    
                return bitmapSource;
            }
    
            /// <summary>
            /// Convert String to ImageFormat
            /// </summary>
            /// <param name="format"></param>
            /// <returns></returns>
            public static System.Drawing.Imaging.ImageFormat ImageFormatFromString(string format)
            {
                if (format.Equals("Jpg"))
                    format = "Jpeg";
                Type type = typeof(System.Drawing.Imaging.ImageFormat);
                BindingFlags flags = BindingFlags.GetProperty;
                object o = type.InvokeMember(format, flags, null, type, null);
                return (System.Drawing.Imaging.ImageFormat)o;
            }
    
            /// <summary>
            /// Read image from path
            /// </summary>
            /// <param name="imageFile"></param>
            /// <param name="imageFormat"></param>
            /// <returns></returns>
            public static byte[] BytesFromImage(String imageFile, System.Drawing.Imaging.ImageFormat imageFormat)
            {
                MemoryStream ms = new MemoryStream();
                Image img = Image.FromFile(imageFile);
                img.Save(ms, imageFormat);
                return ms.ToArray();
            }
    
            /// <summary>
            /// Convert image to byte array
            /// </summary>
            /// <param name="imageIn"></param>
            /// <param name="imageFormat"></param>
            /// <returns></returns>
            public static byte[] ImageToByteArray(System.Drawing.Image imageIn, System.Drawing.Imaging.ImageFormat imageFormat)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, imageFormat);
                return ms.ToArray();
            }
    
            /// <summary>
            /// Byte array to photo
            /// </summary>
            /// <param name="byteArrayIn"></param>
            /// <returns></returns>
            public static Image ByteArrayToImage(byte[] byteArrayIn)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }
