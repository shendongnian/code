    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows.Media.Imaging;
    using Windows.Storage.Streams;
    using Windows.Web.Http;
    public class ImageLoader
    {
        public async static Task<BitmapImage> LoadImage(Uri uri)
        {
            BitmapImage bitmapImage = new BitmapImage();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (var response = await client.GetAsync(uri))
                    {
                        response.EnsureSuccessStatusCode();
                
                        using (IInputStream inputStream = await response.Content.ReadAsInputStreamAsync())
                        {
                            bitmapImage.SetSource(inputStream.AsStreamForRead());
                        }
                    }
                }
                return bitmapImage;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to load the image: {0}", ex.Message);
            }
            
            return null;
        }
    }
