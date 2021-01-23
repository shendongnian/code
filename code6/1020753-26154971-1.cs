        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var str = "hello";
            var format = new StringFormat {Alignment = StringAlignment.Center};
            e.Graphics.DrawString(str, Font, new SolidBrush(Color.Black), new Rectangle(0, 0, Width, Height), format);
            //measuring part
            var region = MeasureStringBounds(e.Graphics, str, Font, new RectangleF(0, 0, Width, Height), format);
            //Draw measured region
            e.Graphics.DrawRectangle(new Pen(Color.Red), region.X, region.Y, region.Width, region.Height);
        }
