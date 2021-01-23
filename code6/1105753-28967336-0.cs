    AddHandler(UIElement.GotMouseCaptureEvent,
        new MouseEventHandler(OnGotMouseCapture), true);
    ...
    void OnGotMouseCapture(object sender, MouseEventArgs e)
    {
        if (e.OriginalSource is TextBox)
        {
            // ...
        }
    }
