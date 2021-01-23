    private async Task CreateSaveBitmapAsync(Canvas canvas)
    {
        if (canvas != null)
        {
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap();
            await renderTargetBitmap.RenderAsync(canvas);
    
            var picker = new FileSavePicker();
            picker.FileTypeChoices.Add("JPEG Image", new string[] { ".jpg" });
            StorageFile file = await picker.PickSaveFileAsync();
            if (file != null)
            {
                var pixels = await renderTargetBitmap.GetPixelsAsync();
    
                using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    var encoder = await
                        BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
                    byte[] bytes = pixels.ToArray();
                    encoder.SetPixelData(BitmapPixelFormat.Bgra8,
                                         BitmapAlphaMode.Ignore,
                                         (uint)element.Width, (uint)element.Height,
                                         96, 96, bytes);
    
                    await encoder.FlushAsync();
                }
            } 
        }
    }
