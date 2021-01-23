            // render content into image
            var render = new RenderTargetBitmap((int)ContentPresenter.RenderSize.Width, (int)ContentPresenter.RenderSize.Height, 96, 96, PixelFormats.Default);
            render.Render(ContentPresenter);
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(render));
            using (var stream = new MemoryStream())
            {
                // create bitmap image
                encoder.Save(stream);
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                bitmap.Freeze();
                // use BitmapImage
                ...
            }
