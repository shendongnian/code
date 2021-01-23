    var rawData = pixelMap.ToByteArray();
            using (var provider = new CGDataProvider(rawData, 0, rawData.Length))
            {
                using (var colorSpace = CGColorSpace.CreateDeviceRGB())
                {
                    var cgImage = new CGImage(
                        pixelMap.Width,
                        pixelMap.Height,
                        pixelMap.BitsPerComponent,
                        pixelMap.BytesPerPixel * ByteToBit,
                        pixelMap.BytesPerPixel * pixelMap.Width,
                        colorSpace,
                        CGBitmapFlags.ByteOrderDefault,
                        provider,
                        null,
                        true,
                        CGColorRenderingIntent.Default
                    );
                    return ImageSource.FromStream(() => UIImage.FromImage(cgImage).AsPNG().AsStream());
                }
            }
