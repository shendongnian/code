    windowObj.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate()
    {
        // Do some changes on the window, like changing textbox content, ...
        // TextBox1.Text = "test";
    });
