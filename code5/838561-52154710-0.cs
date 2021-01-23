        Pointer pointer;
        PointerPoint scrollMousePoint ;
        double hOff = 1;
        private void MainScrollviewer_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            pointer = e.Pointer;
            scrollMousePoint = e.GetCurrentPoint(scrollviewer);
            hOff = scrollviewer.HorizontalOffset;
            scrollviewer.CapturePointer(pointer);
        }
        private void MainScrollviewer_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            scrollviewer.ReleasePointerCaptures();
        }
        private void MainScrollviewer_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (scrollviewer.PointerCaptures!= null&& scrollviewer.PointerCaptures.Count>0)
            {
              scrollviewer.ChangeView(hOff + (scrollMousePoint.Position.X - e.GetCurrentPoint(scrollviewer).Position.X),null,null);
            }
        }
