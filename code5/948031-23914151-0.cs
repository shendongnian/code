    private void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        IInputElement element = e.MouseDevice.DirectlyOver;
        if (element != null && element is FrameworkElement)
        {
            Button button = GetParentOfType<Button>(element as FrameworkElement);
            if (button != null)
            {
                // The Button was clicked
            }
            else e.Handled = true;
        }
        else e.Handled = true;
    }
