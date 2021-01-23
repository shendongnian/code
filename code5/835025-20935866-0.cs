    private void PinPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (BottomAppBar != null) BottomAppBar.IsOpen = false;
            MapView.CapturePointer(e.Pointer);
            ...
        }
