    public void Initialize() {
        // Initialize your listener and set up event listeners
        MyMouseHookListener = new MouseHookListener(new AppHooker()) {Enabled = true};
        MyMouseHookListener.MouseDownExt += MyMouseHookListenerOnMouseDownExt;
        // UNDONE Delete when testing is done; included to show that the listener is never called
        MyMouseHookListener.MouseDoubleClick += MyMouseHookListenerOnMouseDoubleClick;
    }
    private static void MyMouseHookListenerOnMouseDoubleClick(object sender, MouseEventArgs mouseEventArgs)
    {
        // NOTE: This listener should never be called
        Debug.Print("Mouse double-click!");
    }
    private static void MyMouseHookListenerOnMouseDownExt(object sender, MouseEventExtArgs mouseEventExtArgs)
    {
        Debug.Print("Mouse down. Number of clicks: {0}", mouseEventExtArgs.Clicks);
        if (mouseEventExtArgs.Clicks == 2)
        {
            // TODO Insert your double-click code here
            mouseEventExtArgs.Handled = true;
        }
    }
