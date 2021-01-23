    private void Target_PointerMoved(object sender, PointerRoutedEventArgs e)
    {
        var ptr = e.Pointer;
        if (ptr.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse)
        {
            var ptrPt = e.GetCurrentPoint(Target);
        }
        e.Handled = true;
    }
