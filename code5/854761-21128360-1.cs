    namespace MyExtensionMethods
    {
        public static class CanvasExtensions
        {
            public static int AddChild(this Canvas canvas, UIElement element, int x, int y)
            {
                Canvas.SetLeft(element, x);
                Canvas.SetTop(element, y);
                return canvas.Children.Add(element);
            }
        }
    }
