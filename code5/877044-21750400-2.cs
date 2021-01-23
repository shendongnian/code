        private void Send()
        {
            float l = 25, r = 20; // Testing values
            mRectangle1 = new RectangleF(59, 74, 16, 56 * (l / 100));
            mRectangle2 = new RectangleF(81, 74, 16, 56 * (r / 100));
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Brush brush = new SolidBrush(Color.LimeGreen))
            {
                e.Graphics.FillRectangle(brush, mRectangle1);
                e.Graphics.FillRectangle(brush, mRectangle2);
            }
        }
        private RectangleF mRectangle1;
        private RectangleF mRectangle2;
