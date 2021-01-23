    class Plexiglass : Control
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Parent != null)
            {
                Bitmap plexiCover = new Bitmap(Parent.Width, Parent.Height);
                foreach (Control c in Parent.Controls)
                    if (c.Bounds.IntersectsWith(this.Bounds) & c != this)
                        c.DrawToBitmap(plexiCover, c.Bounds);
                e.Graphics.DrawImage(plexiCover, -Left, -Top);
                plexiCover.Dispose();
            }
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 0, 0)), Bounds);
        }
    }
