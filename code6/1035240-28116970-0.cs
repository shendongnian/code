    private async void CapturePhoto()
        {
            string photoPath = string.Empty;
            ImageEncodingProperties format = ImageEncodingProperties.CreateJpeg();
            using (var imageStream = new InMemoryRandomAccessStream())
            {
                await MediaCapture.CapturePhotoToStreamAsync(format, imageStream);
                BitmapDecoder dec = await BitmapDecoder.CreateAsync(imageStream);
                BitmapEncoder enc = await BitmapEncoder.CreateForTranscodingAsync(imageStream, dec);
                enc.BitmapTransform.Rotation = BitmapRotation.Clockwise90Degrees;
                await enc.FlushAsync();
                StorageFolder folder = ApplicationData.Current.LocalFolder;
                StorageFile capturefile = await folder.CreateFileAsync("photo.jpg", CreationCollisionOption.GenerateUniqueName);
                photoPath = capturefile.Name;
 
                using (var fileStream = await capturefile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    try
                    {  
                        await RandomAccessStream.CopyAsync(imageStream, fileStream);
                    }
                    catch {}
                }
            } 
        }
