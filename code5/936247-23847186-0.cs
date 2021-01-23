            Rect r = new Rect(new Point(0, 0), new Point(canvas.Width, canvas.Height));
            foreach (var c in canvas.Children)
                c.Clip = new RectangleGeometry() { Rect = r };
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap();
            await renderTargetBitmap.RenderAsync(canvas, (int)canvas.Width, (int)canvas.Height);
            FileSavePicker picker = new FileSavePicker();
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
                        (uint)canvas.Width, (uint)canvas.Height,
                        96, 96, bytes);
                    await encoder.FlushAsync();
                }
            }
