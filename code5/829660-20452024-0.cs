    public static class RectangleExtensions
    {
        public static bool IntersectsOnX(this Rectangle rect, int xPoint)
        {
            return rect.Left <= xPoint && xPoint <= rect.Right;
        }
        public static bool IntersectsOnY(this Rectangle rect, int yPoint)
        {
            return rect.Top <= yPoint && yPoint <= rect.Bottom;
        }
    }
