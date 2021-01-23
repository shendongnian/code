     private void Thumb_OnDragDeltanDragDelta(object sender, DragDeltaEventArgs e)
        {
            var source = PresentationSource.FromVisual(this);
            Point position = Mouse.GetPosition(this);
            var hwndSource = PresentationSource.FromVisual((Visual)sender) as HwndSource;
            Matrix transformToDevice = source.CompositionTarget.TransformToDevice;
            Point[] p = { new Point(Left, Top), new Point(position.X, position.Y) };
            transformToDevice.Transform(p);
            SetWindowPos(hwndSource.Handle, IntPtr.Zero, Convert.ToInt32(p[0].X), Convert.ToInt32(p[0].Y), Convert.ToInt32(p[1].X), Convert.ToInt32(p[1].Y), SetWindowPosFlags.SWP_SHOWWINDOW);
        }
