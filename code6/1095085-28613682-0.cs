    public static class BitmapExtensions
    {
        public static async void SetImageURL(this ImageView imageView, string url)
        {
            using (IBitmap bmp = await App1.Shared.ImageDownloadService.DownloadImage(url, imageView.Width, imageView.Height))
            {
                if (bmp != null)
                {
                    using(var nativeBmp = bmp.ToNative())
                        imageView.SetImageDrawable(nativeBmp);
                }
            }
        }
    }
