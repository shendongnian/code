        public async static Task<BitmapImage> LoadImage(Uri uri)
        {
            BitmapImage bitmapImage = new BitmapImage();
            try
            {
                using (Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient())
                {
                    using (var response = await client.GetAsync(uri))
                    {
                        response.EnsureSuccessStatusCode();
                        using (MemoryStream inputStream = new MemoryStream())
                        {
                            await inputStream.CopyToAsync(inputStream);
                            bitmapImage.SetSource(inputStream.AsRandomAccessStream());
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
