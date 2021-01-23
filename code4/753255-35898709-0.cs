    public static class LinearGratientBrushExtensions
    {
        public static Color AverageColor(this LinearGradientBrush brush)
        {
            return brush.GradientStops[(int)Math.Round((double)((brush.GradientStops.Count() - 1) / 2), 0)].Color;
        }
    }
