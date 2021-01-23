                memStream.Size = 0;
                var encoder = await BitmapEncoder.CreateAsync(Windows.Graphics.Imaging.BitmapEncoder.JpegEncoderId, memStream);
                encoder.SetPixelData(
                Windows.Graphics.Imaging.BitmapPixelFormat.Bgra8,
                Windows.Graphics.Imaging.BitmapAlphaMode.Straight,
                CanvasWidth, // pixel width
                CanvasHeight, // pixel height
                96, // horizontal DPI
                96, // vertical DPI
                PixelData
                );
                try
                {
                    await encoder.FlushAsync();
                }
                catch
                {
    
                }
                memStream.Dispose();
