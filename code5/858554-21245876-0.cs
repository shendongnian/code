        public void Save(IRandomAccessStream stream)
        {
            var textureCopy = new Texture2D(_device, new Texture2DDescription
            {
                Width = (int)width,
                Height = (int)height,
                MipLevels = 1,
                ArraySize = 1,
                Format = Format.B8G8R8A8_UNorm,
                Usage = ResourceUsage.Staging,
                SampleDescription = new SampleDescription(1, 0),
                BindFlags = BindFlags.None,
                CpuAccessFlags = CpuAccessFlags.Read,
                OptionFlags = ResourceOptionFlags.None
            });
            _d3dContext.CopyResource(sourceTexture, textureCopy);
            DataStream dataStream;
            var dataBox = _d3dContext.MapSubresource(
                textureCopy,
                0,
                0,
                MapMode.Read,
                SharpDX.Direct3D11.MapFlags.None,
                out dataStream);
            var dataRectangle = new DataRectangle
            {
                DataPointer = dataStream.DataPointer,
                Pitch = dataBox.RowPitch
            };
            var bitmap = new Bitmap(
                _deviceManager.WICFactory,
                textureCopy.Description.Width,
                textureCopy.Description.Height,
                PixelFormat.Format32bppBGRA,
                dataRectangle);
            using (var s = stream.AsStream())
            {
                s.Position = 0;
                using (var bitmapEncoder = new PngBitmapEncoder(_deviceManager.WICFactory, s))
                {
                    using (var bitmapFrameEncode = new BitmapFrameEncode(bitmapEncoder))
                    {
                        bitmapFrameEncode.Initialize();
                        bitmapFrameEncode.SetSize(bitmap.Size.Width, bitmap.Size.Height);
                        var pixelFormat = PixelFormat.FormatDontCare;
                        bitmapFrameEncode.SetPixelFormat(ref pixelFormat);
                        bitmapFrameEncode.WriteSource(bitmap);
                        bitmapFrameEncode.Commit();
                        bitmapEncoder.Commit();
                    }
                }
            }
            _d3dContext.UnmapSubresource(textureCopy, 0);
            textureCopy.Dispose();
            bitmap.Dispose();
        }
