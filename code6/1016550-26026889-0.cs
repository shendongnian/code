        private async Task DrawToFile()
        {
            RenderTargetBitmap renderTargetBitmapZ = new RenderTargetBitmap();
            await renderTargetBitmapZ.RenderAsync(ResultGrid);
            var pixels = await renderTargetBitmapZ.GetPixelsAsync();
            var file = await KnownFolders.PicturesLibrary.CreateFileAsync("picresult.jpg", CreationCollisionOption.ReplaceExisting);
            using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                var encoder = await
                    BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
                byte[] bytes = pixels.ToArray();
                encoder.SetPixelData(BitmapPixelFormat.Bgra8,
                                     BitmapAlphaMode.Ignore,
                                     (uint)renderTargetBitmapZ.PixelWidth,
                                     (uint)renderTargetBitmapZ.PixelHeight,
                                     96, 96, bytes);
                await encoder.FlushAsync();
            }
        }
