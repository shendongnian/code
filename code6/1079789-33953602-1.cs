        /// <summary>
        /// Use to draw some text using font file location.
        /// </summary>
        /// <param name="font">Font file location</param>
        /// <param name="someText"></param>
        /// <param name="fontSize"></param>
        /// <param name="width">bitmap width</param>
        /// <param name="height">bitmap height</param>
        /// <returns>new instance of RenderTargetBitmap</returns>
        private static RenderTargetBitmap DrawText(string font, string someText, int fontSize, int width = 700, int height = 300)
        {
            var name = Path.GetFileName(font);
            var glyphTypeface = new GlyphTypeface(new Uri(font));
            string family = String.Join(" ", glyphTypeface.FamilyNames.Values.ToArray<string>());
            var style = glyphTypeface.Style;
            var weight = glyphTypeface.Weight;
            var fontStretch = glyphTypeface.Stretch;
            string fontUri = new Uri(font.Replace(name, ""), UriKind.RelativeOrAbsolute).AbsoluteUri + "/#" + family;
            var fontFamily = new FontFamily(fontUri);
            var typeface = new Typeface(fontFamily, style, weight, fontStretch);
            var formattedText = new FormattedText(someText, System.Globalization.CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                typeface, fontSize, 
                Brushes.Black);
            formattedText.TextAlignment = TextAlignment.Center;
            var drawingVisual = new DrawingVisual();
            RenderOptions.SetBitmapScalingMode(drawingVisual, BitmapScalingMode.HighQuality);
            RenderOptions.SetEdgeMode(drawingVisual, EdgeMode.Aliased);
            TextOptions.SetTextRenderingMode(drawingVisual, TextRenderingMode.Aliased);
            using (var drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawRectangle(Brushes.White, null, new Rect(0, 0, width, height));
                var geometry = formattedText.BuildGeometry(new Point(0, 0));
                var bounds = geometry.Bounds;
                var sW = width / bounds.Width;
                var sH = height / bounds.Height;
                var ratio = sH <= sW ? sH : sW;
                if (ratio > 1) ratio = 1;
                var translateX = (width - bounds.Width * ratio) / 2;
                var translateY = (height - bounds.Height * ratio) / 2;
                var transformGroup = new TransformGroup();
                transformGroup.Children.Add(new ScaleTransform(ratio, ratio));
                transformGroup.Children.Add(new TranslateTransform(-bounds.X * ratio + translateX, -bounds.Y * ratio + translateY));
                geometry.Transform = transformGroup;
                drawingContext.DrawGeometry(Brushes.Black, null, geometry);
            }
            var renderTargetBitmap = new RenderTargetBitmap(
                width, height,
                0, 0,
                PixelFormats.Pbgra32);
            renderTargetBitmap.Render(drawingVisual);
            return renderTargetBitmap;
        }
