    public MyItem(Control control)
    {
        if (control != null)
        {
            Control rootParent = control;
            while (rootParent.Parent != null)
                rootParent = rootParent.Parent;
            rootParent.BringToFront();
            _bounds = control.Bounds;
            Rectangle controlBounds;
            if (control.Parent == null)
            {
                _bounds = new Rectangle(new Point(0, 0), control.Bounds.Size);
                controlBounds = _bounds;
            }
            else
            {
                _bounds.Intersect(control.Parent.ClientRectangle);
                _bounds = new Rectangle(rootParent.PointToClient(control.Parent.PointToScreen(_bounds.Location)), _bounds.Size);
                controlBounds = new Rectangle(rootParent.PointToClient(control.Parent.PointToScreen(control.Location)), control.Size);
            }
            if (_bounds.Height > 0 && _bounds.Width > 0)
            {
                _controlBitmap = new Bitmap(_bounds.Width, _bounds.Height);
                using (Graphics bitmapGraphics = Graphics.FromImage(_controlBitmap))
                {
                    if (control.Parent == null)
                    {
                        Form form = control as Form;
                        Boolean currentTopMost = form.TopMost;
                        form.TopMost = true;
                        control.BringToFront();
                        bitmapGraphics.CopyFromScreen(control.Location, Point.Empty, _bounds.Size);
                        form.TopMost = currentTopMost;
                    }
                    else
                    {
                        IntPtr hDC = IntPtr.Zero;
                        try
                        {
                            hDC = control.CreateGraphics().GetHdc();
                            IntPtr bitmapHandle = bitmapGraphics.GetHdc();
                            Win32.BitBlt(bitmapHandle, 0, 0, _bounds.Width, _bounds.Height, hDC, _bounds.X - controlBounds.X, _bounds.Y - controlBounds.Y, 13369376);
                            bitmapGraphics.ReleaseHdc(bitmapHandle);
                        }
                        finally
                        {
                            if (hDC != IntPtr.Zero)
                                Win32.ReleaseDC(control.Handle, hDC);
                        }
                    }
                }
            }
        }
    }
