     public static BitmapSource CaptureScreen(this UIElement visualElement, int? desiredLongestEdge = null)
        {
            double scale = 1;
            if (desiredLongestEdge.HasValue)
            {
                if (visualElement.RenderSize.Width > visualElement.RenderSize.Height)
                {
                    scale = desiredLongestEdge.Value/ visualElement.RenderSize.Width;
                }
                else
                {
                    scale = desiredLongestEdge.Value / visualElement.RenderSize.Height ;
                }
            }
            var targetBitmap =
                         new RenderTargetBitmap(
                            (int) Math.Ceiling(scale * (visualElement.RenderSize.Width + 1)),
                             (int) Math.Ceiling(scale * (visualElement.RenderSize.Height + 1)),
                                                           scale * 96,
                                                           scale * 96,
                                                            PixelFormats.Pbgra32);
            visualElement.Measure(visualElement.RenderSize); //Important
            visualElement.Arrange(new Rect(visualElement.RenderSize)); //Important
            targetBitmap.Render(visualElement);
            return targetBitmap;
        }
