        public BitmapSource SnapShotPNG(UIElement source)
        {
            double actualWidth = source.RenderSize.Width;
            double actualHeight = source.RenderSize.Height;
            RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)actualWidth, (int)actualHeight, 96, 96, PixelFormats.Pbgra32);
            DrawingVisual visual = new DrawingVisual();
            using (DrawingContext context = visual.RenderOpen())
            {
                VisualBrush sourceBrush = new VisualBrush(source);
                context.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0), new Point(actualWidth, actualHeight)));
            }
            source.Measure(source.RenderSize); //Important
            source.Arrange(new Rect(source.RenderSize)); //Important
            renderTarget.Render(visual);
            try
            {
                return new CroppedBitmap(renderTarget, new Int32Rect(0, 0, (int)actualWidth, (int)actualHeight));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
