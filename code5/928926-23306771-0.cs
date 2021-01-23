    public static class ExtensionMethods
    {
        public static Point RightPoint(this Rectangle rectangle)
        {
            return new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height / 2);
        }
    }
