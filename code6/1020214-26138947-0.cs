    using GDI = System.Drawing;
    private int _counter; // count redraws
    protected override void OnRender(DrawingContext context)
    {
        if (Figures != null && RenderSize.Height > 0 && RenderSize.Width > 0)
            using (var bitmap = new GDI.Bitmap((int)RenderSize.Width, (int)RenderSize.Height))
            {
                using (var graphics = GDI.Graphics.FromImage(bitmap))
                    foreach (var figure in Figures)
                        figure.Render(this, graphics);
                // draw image
                var hbitmap = bitmap.GetHbitmap();
                var size = bitmap.Width * bitmap.Height * 4;
                GC.AddMemoryPressure(size);
                var image = Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                image.Freeze();
                context.DrawImage(image, new Rect(RenderSize));
                DeleteObject(hbitmap);
                GC.RemoveMemoryPressure(size);
                // trigger garbage collecting
                if (_counter++ > 10)
                    GC.Collect(3);
          }
    }
