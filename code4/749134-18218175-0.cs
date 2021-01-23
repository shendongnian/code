    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    namespace ImageProcessing
    {
        public class ImageProc
        {
            public RenderTargetBitmap GetImage(UIElement source)
            {
                double actualHeight = source.RenderSize.Height;
                double actualWidth = source.RenderSize.Width;
    
                if (actualHeight > 0 && actualWidth > 0)
                {
                    RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)actualWidth, (int)actualHeight, 96, 96, PixelFormats.Pbgra32);
                    VisualBrush sourceBrush = new VisualBrush(source);
                    DrawingVisual drawingVisual = new DrawingVisual();
                    DrawingContext drawingContext = drawingVisual.RenderOpen();
                    drawingContext.DrawRectangle(sourceBrush, null, new Rect(0, 0, actualWidth, actualHeight));
                    drawingContext.Close();
                    renderTarget.Render(drawingVisual);
                    return renderTarget;
                }
                else
                    return null;
            }
        }
    }
