        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            var rc = new Rectangle(20, 20, this.ClientSize.Width - 40, 50);
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                rc, 
                Color.FromArgb(255, Color.BlueViolet), 
                Color.FromArgb(0,   Color.BlueViolet), 
                0f)) {
                    e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                    e.Graphics.FillRectangle(brush, rc);
            }
        }
