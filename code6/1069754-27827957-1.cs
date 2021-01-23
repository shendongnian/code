    using Android.App;
    using Android.Graphics;
    using Klaim.Interfaces;
    using Klaim.Droid.Renderers;
    using System;
    using System.IO;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    
    [assembly: Xamarin.Forms.Dependency (typeof (ImageResizer_Android))]
    namespace Klaim.Droid.Renderers
    {
        public class ImageResizer_Android : IImageResizer
        {
            public ImageResizer_Android () {}
            public byte[] ResizeImage (byte[] imageData, float width, float height)
            {
    
                // Load the bitmap
                Bitmap originalImage = BitmapFactory.DecodeByteArray (imageData, 0, imageData.Length);
                Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)width, (int)height, false);
    
                using (MemoryStream ms = new MemoryStream())
                {
                    resizedImage.Compress (Bitmap.CompressFormat.Jpeg, 100, ms);
                    return ms.ToArray ();
                }
            }
        }
    }
