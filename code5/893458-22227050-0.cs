    /// <summary>
    /// Collection of often-used classes and methods for easy access.
    /// </summary>
    public class RoundedDrawing
    {
        private static GraphicsPath GetRoundedRectanglePath(Int32 x, Int32 y, Int32 width, Int32 height, Int32 radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(x + radius, y, x + width - radius, y);
            if (radius > 0)
                path.AddArc(x + width - 2 * radius, y, 2 * radius, 2 * radius, 270.0f, 90.0f);
            path.AddLine(x + width, y + radius, x + width, y + height - radius);
            if (radius > 0)
                path.AddArc(x + width - 2 * radius, y + height - 2 * radius, 2 * radius, 2 * radius, 0.0f, 90.0f);
            path.AddLine(x + width - radius, y + height, x + radius, y + height);
            if (radius > 0)
                path.AddArc(x, y + height - 2 * radius, 2 * radius, 2 * radius, 90.0f, 90.0f);
            path.AddLine(x, y + height - radius, x, y + radius);
            if (radius > 0)
                path.AddArc(x, y, 2 * radius, 2 * radius, 180.0f, 90.0f);
            return path;
        }
        /// <summary>
        /// Fills the interior of a rounded rectangle.
        /// </summary>
        public static void FillRoundedRectangle(Graphics graphics, Brush brush, float x, float y, float width, float height, float radius)
        {
            FillRoundedRectangle(graphics, brush, (Int32)x, (Int32)y, (Int32)width, (Int32)height, (Int32)radius);
        }
        /// <summary>
        /// Fills the interior of a rounded rectangle.
        /// </summary>
        public static void FillRoundedRectangle(Graphics graphics, Brush brush, Rectangle rect, Int32 radius)
        {
            FillRoundedRectangle(graphics, brush, rect.Left, rect.Top, rect.Width, rect.Height, radius);
        }
        /// <summary>
        /// Fills the interior of a rounded rectangle.
        /// </summary>
        public static void FillRoundedRectangle(Graphics graphics, Brush brush, RectangleF rect, float radius)
        {
            FillRoundedRectangle(graphics, brush, (Int32)rect.Left, (Int32)rect.Top, (Int32)rect.Width, (Int32)rect.Height, (Int32)radius);
        }
        /// <summary>
        /// Fills the interior of a rounded rectangle.
        /// </summary>
        public static void FillRoundedRectangle(Graphics graphics, Brush brush, Int32 x, Int32 y, Int32 width, Int32 height, Int32 radius)
        {
            using (GraphicsPath path = GetRoundedRectanglePath(x, y, width, height, radius))
                graphics.FillPath(brush, path);
        }
        /// <summary>
        /// Draws the outline of a rounded rectangle.
        /// </summary>
        public static void DrawRoundedRectangle(Graphics graphics, Pen pen, float x, float y, float width, float height, float radius)
        {
            DrawRoundedRectangle(graphics, pen, (Int32)x, (Int32)y, (Int32)width, (Int32)height, (Int32)radius);
        }
        /// <summary>
        /// Draws the outline of a rounded rectangle.
        /// </summary>
        public static void DrawRoundedRectangle(Graphics graphics, Pen pen, Rectangle rect, Int32 radius)
        {
            DrawRoundedRectangle(graphics, pen, rect.Left, rect.Top, rect.Width, rect.Height, radius);
        }
        /// <summary>
        /// Draws the outline of a rounded rectangle.
        /// </summary>
        public static void DrawRoundedRectangle(Graphics graphics, Pen pen, RectangleF rect, float radius)
        {
            DrawRoundedRectangle(graphics, pen, (Int32)rect.Left, (Int32)rect.Top, (Int32)rect.Width, (Int32)rect.Height, (Int32)radius);
        }
        /// <summary>
        /// Draws the outline of a rounded rectangle.
        /// </summary>
        public static void DrawRoundedRectangle(Graphics graphics, Pen pen, Int32 x, Int32 y, Int32 width, Int32 height, Int32 radius)
        {
            using (GraphicsPath path = GetRoundedRectanglePath(x, y, width, height, radius))
                graphics.DrawPath(pen, path);
        }
    }
