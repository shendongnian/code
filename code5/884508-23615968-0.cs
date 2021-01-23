    public static class BrushExtension
    {
        public static Color GetColor(this Brush brush)
        {
            return new Pen(brush).Color;
        }
    }
