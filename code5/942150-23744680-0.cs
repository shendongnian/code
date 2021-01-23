        public static async Task SetSourceAsync(
            this WriteableBitmap writeableBitmap,
            IRandomAccessStream streamSource,
            uint decodePixelWidth,
            uint decodePixelHeight)
        {
            var decoder = await BitmapDecoder.CreateAsync(streamSource);
            using (var inMemoryStream = new InMemoryRandomAccessStream())
            {
                var encoder = await BitmapEncoder.CreateForTranscodingAsync(inMemoryStream, decoder);
                encoder.BitmapTransform.ScaledWidth = decodePixelWidth;
                encoder.BitmapTransform.ScaledHeight = decodePixelHeight;
                await encoder.FlushAsync();
                inMemoryStream.Seek(0);
                await writeableBitmap.SetSourceAsync(inMemoryStream);
            }
        }
