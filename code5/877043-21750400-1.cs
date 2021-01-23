        private void Send()
        {
            mRectangle = new Rectangle(20, 20, 56, 56);
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Brush brush = new SolidBrush(Color.LimeGreen))
            {
                e.Graphics.FillRectangle(brush, mRectangle);
            }
        }
        private Rectangle mRectangle;
