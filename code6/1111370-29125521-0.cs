    class CustomControl : Control
    {
        private bool mShouldDrawMouseRect;
        private Rectangle mMouseRect;
    
        public CustomControl()
        {
            this.mMouseRect.Width = 500;
            this.mMouseRect.Height = 500;
            
            this.SetStyle(
                ControlStyles.DoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.AllPaintingInWmPaint, 
                true);
        }
        
        protected override void OnMouseEnter(EventArgs e)
        {
            // No actual painting done here, just updating fields.
            this.mShouldDrawMouseRect = true;
            this.Invalidate();
        }
        
        protected override void OnMouseLeave(EventArgs e)
        {
            // No actual painting done here, just updating fields.
            this.mShouldDrawMouseRect = false;
            this.Invalidate();
        }
        
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // No actual painting done here, just updating fields.
            this.mMouseRect.X = e.X;
            this.mMouseRect.Y = e.Y;
            this.Invalidate();
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            // ALL painting stays in the paint event, using the graphics provided
            if (this.mShouldDrawMouseRect)
            {
                // If you're just using named colors, we can access the static Pen objects.
                e.Graphics.DrawRectangle(Pens.Chocolate, this.mMouseRect);
                // If you create your own Pen, put it in a Using statement.
                // Including the following commented example:
                
                // using (var pen = new Pen(Color.Chocolate))
                // {
                //     e.Graphics.DrawRectangle(pen, this.mMouseRect);
                // }
            }
        }
    }
