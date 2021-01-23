    public static class RectExtensions
    {
        public static string ToStringRounded(this System.Windows.Rect rect)
        {
            return string.Format("{0},{1},{2},{3}", 
                Math.Round(rect.X, 2), Math.Round(rect.Y, 2), 
                Math.Round(rect.Width, 2), Math.Round(rect.Height, 2));
        }
    }
