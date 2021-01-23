        public static class CanvasExtensions
        {
            public static void TransformElements(this Canvas canvas,
                Action<CanvasElement> transform)
            {
                ...
                foreach(var elem in canvas.Children)
                {
                    transform(elem);
                }
                ...
            }
        }
