    public class BarTextRenderer : BarRenderer
    {
        #region Constructors
        /// <summary>
        /// Make a BarTextRenderer
        /// </summary>
        public BarTextRenderer() : base() {}
        /// <summary>
        /// Make a BarTextRenderer for the given range of data values
        /// </summary>
        public BarTextRenderer (int minimum, int maximum) : base(minimum, maximum) { }
        /// <summary>
        /// Make a BarTextRenderer using a custom bar scheme
        /// </summary>
        public BarTextRenderer (Pen pen, Brush brush) : base(pen, brush) { }
        /// <summary>
        /// Make a BarTextRenderer using a custom bar scheme
        /// </summary>
        public BarTextRenderer (int minimum, int maximum, Pen pen, Brush brush) : base(minimum, maximum, pen, brush) { }
        /// <summary>
        /// Make a BarTextRenderer that uses a horizontal gradient
        /// </summary>
        public BarTextRenderer (Pen pen, Color start, Color end) : base(pen, start, end) { }
        /// <summary>
        /// Make a BarTextRenderer that uses a horizontal gradient
        /// </summary>
        public BarTextRenderer (int minimum, int maximum, Pen pen, Color start, Color end) : base(minimum, maximum, pen, start, end) { }
        #endregion
      public override void Render(Graphics g, Rectangle r)
      {
        base.Render(g, r);
        float x = r.X + (float)r.Width / 2f;
        float w = r.Width/2f;
        float h = Math.Max (r.Height-this.Font.Size, 0.8f*r.Height);
        float y = (float)r.Y + 0.6f*(r.Height-h);
        
        RectangleF rf = new RectangleF(x, y, w, h);
        g.DrawString(this.Aspect.ToString(), this.Font, this.Brush, rf);
      }
    }
