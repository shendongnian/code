            Graphics g = e.Graphics;
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(192, 99, 104, 113)))
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddRectangle(new Rectangle(e.ClipRectangle.X + (e.ClipRectangle.Width - 40) / 2, e.ClipRectangle.Y, 40, e.ClipRectangle.Height));
                    path.AddRectangle(new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y + (e.ClipRectangle.Height - 40) / 2, e.ClipRectangle.Width, 40));
                    path.FillMode = FillMode.Winding;
                    using (Region region = new Region(path))
                    {
                        IntPtr reg = region.GetHrgn(g);
                        IntPtr hdc = g.GetHdc();
                        IntPtr brushPtr = Win32.GetStockObject(Win32.WHITE_BRUSH);
                        IntPtr oldbrushPtr = Win32.SelectObject(hdc, brushPtr);
                        Win32.FrameRgn(hdc, reg, brushPtr, 1, 1);
                        Win32.DeleteObject(brushPtr);
                        Win32.SelectObject(hdc, oldbrushPtr);
                        region.ReleaseHrgn(reg);
                        g.ReleaseHdc();
                    }
                }
            }
