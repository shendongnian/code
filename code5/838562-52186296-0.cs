       System.Windows.Point ScrollMousePoint1 = new System.Windows.Point();
       double HorizontalOff1 = 1; double VerticalOff1 = 1;
       private void ScrollViewer1_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
            {
                ScrollMousePoint1 = e.GetPosition(ScrollViewer1);
                HorizontalOff1 = ScrollViewer1.HorizontalOffset;
                VerticalOff1 = ScrollViewer1.VerticalOffset;
                ScrollViewer1.CaptureMouse();
            }
    
            private void ScrollViewer1_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
            {
                if (ScrollViewer1.IsMouseCaptured)
                {
                    ScrollViewer1.ScrollToHorizontalOffset(HorizontalOff1 + (ScrollMousePoint1.X - e.GetPosition(ScrollViewer1).X));
                    ScrollViewer1.ScrollToVerticalOffset(VerticalOff1 + (ScrollMousePoint1.Y - e.GetPosition(ScrollViewer1).Y));
                }
            }
    
            private void ScrollViewer1_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
            {
                ScrollViewer1.ReleaseMouseCapture();
            }
    
            private void ScrollViewer1_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
            {
                ScrollViewer1.ScrollToHorizontalOffset(ScrollViewer1.HorizontalOffset + e.Delta);
                ScrollViewer1.ScrollToVerticalOffset(ScrollViewer1.VerticalOffset + e.Delta);
            }
