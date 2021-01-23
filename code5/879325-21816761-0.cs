        public ImageSource ApplyTextToBitmapSource(ImageSource backgroundImageSource, string text, Point location, FontFamily font, double fontSize, Brush foreground)
        {
            TextBlock tb = new TextBlock();
            tb.Text = text;
            tb.FontFamily = font;
            tb.FontSize = fontSize;
            tb.Foreground = foreground;
            tb.Margin = new Thickness(location.X, location.Y, 0.0d, 0.0d);
            Image image = new Image();
            image.Stretch = Stretch.Uniform;
            image.Source = backgroundImageSource;
            Grid container = new Grid();
            container.Width = backgroundImageSource.Width;
            container.Height = backgroundImageSource.Height;
            container.Background = new ImageBrush(backgroundImageSource);
            container.Children.Add(tb);
            return RenderElementToBitmap(container, new Size(backgroundImageSource.Width, backgroundImageSource.Height));
        }
        private ImageSource RenderElementToBitmap(FrameworkElement element, Size maxSize)
        {
            element.Measure(maxSize);
            element.Arrange(new Rect(element.DesiredSize));
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)Math.Ceiling(element.ActualWidth),
                (int)Math.Ceiling(element.ActualHeight), 96, 96, PixelFormats.Pbgra32);
            DrawingVisual visual = new DrawingVisual();
            using (DrawingContext ctx = visual.RenderOpen())
            {
                VisualBrush brush = new VisualBrush(element);
                Rect bounds = VisualTreeHelper.GetDescendantBounds(element);
                Rect targetRect = new Rect(0.0d, 0.0d, bounds.Width, bounds.Height);
                ctx.DrawRectangle(brush, null, targetRect);
            }
            renderTargetBitmap.Render(visual);
            return renderTargetBitmap;
        }
