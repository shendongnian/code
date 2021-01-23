    public static class Texture2DExtensions
    {
        public static void Save(this Texture2D texture, IRandomAccessStream stream, DeviceManager deviceManager)
        {
            var textureCopy = new Texture2D(deviceManager.DeviceDirect3D, new Texture2DDescription
            {
                Width = (int)texture.Description.Width,
                Height = (int)texture.Description.Height,
                MipLevels = 1,
                ArraySize = 1,
                Format = texture.Description.Format,
                Usage = ResourceUsage.Staging,
                SampleDescription = new SampleDescription(1, 0),
                BindFlags = BindFlags.None,
                CpuAccessFlags = CpuAccessFlags.Read,
                OptionFlags = ResourceOptionFlags.None
            });
            deviceManager.ContextDirect3D.CopyResource(texture, textureCopy);
            DataStream dataStream;
            var dataBox = deviceManager.ContextDirect3D.MapSubresource(
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
                deviceManager.WICFactory,
                textureCopy.Description.Width,
                textureCopy.Description.Height,
                PixelFormat.Format32bppBGRA,
                dataRectangle);
            using (var s = stream.AsStream())
            {
                s.Position = 0;
                using (var bitmapEncoder = new PngBitmapEncoder(deviceManager.WICFactory, s))
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
            deviceManager.ContextDirect3D.UnmapSubresource(textureCopy, 0);
            textureCopy.Dispose();
            bitmap.Dispose();
        }
    }
