    public async void downLoadImage(string url)
    {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                BitmapImage bitmap = new BitmapImage();
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        using (var memStream = new MemoryStream())
                        {
                            await stream.CopyToAsync(memStream);
                            memStream.Position = 0;
                            bitmap.SetSource(memStream.AsRandomAccessStream());
                        }
                    }
                    HardcodedValues.profilePic = bitmap;
                }
            }
    }
