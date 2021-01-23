            // get image from URL, ImageName is an absolute Url
            public static async Task<BitmapImage> GetWebImageByImageName(string ImageName)
            {
                //Uri imageServerUril = new Uri(ImageName);
    
                var byteArray = await client.GetByteArrayAsync(ImageName);
                
    
                //Convert byte array to BitmapImage       
                BitmapImage bitmapImage; 
                using (MemoryStream ms = new MemoryStream(byteArray))
                {
                   bitmapImage = new BitmapImage();
                    bitmapImage.SetSource(ms);
                }
    
                return bitmapImage;
    
    
            }
