     void Pan_MouseMove(object sender, MouseEventArgs e)
        {
            if (!((Path)sender).IsMouseCaptured) return;
            Point p = e.MouseDevice.GetPosition(clipBorder);
            if (p.X > 0 && p.Y > 0 && p.X < clipBorder.ActualWidth && p.Y < clipBorder.ActualHeight)
            {
                Matrix m = CanvasPanel.RenderTransform.Value;
                m.OffsetX = origin.X + (p.X - start.X);
                m.OffsetY = origin.Y + (p.Y - start.Y);
                CanvasPanel.RenderTransform = new MatrixTransform(m);
            }
        }
