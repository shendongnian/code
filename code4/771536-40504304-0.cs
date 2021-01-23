     public async void Base64ToImage(string base64String)
            {
                // read stream
                var bytes = Convert.FromBase64String(base64String);
                var image = bytes.AsBuffer().AsStream().AsRandomAccessStream();
    
                // decode image
                var decoder = await BitmapDecoder.CreateAsync(image);
                image.Seek(0);
    
                // create bitmap
                var output = new WriteableBitmap((int)decoder.PixelHeight, (int)decoder.PixelWidth);
                await output.SetSourceAsync(image);
    
                camImage.Source = output;
            }
