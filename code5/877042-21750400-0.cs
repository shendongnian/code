        protected override void OnPaint(PaintEventArgs e)
        {
            using (Brush brush = new SolidBrush(Color.LimeGreen))
            {
                e.Graphics.FillRectangle(brush, 20, 20, 56, 56);
            }
            base.OnPaint(e);
        }
