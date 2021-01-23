    private void DoEvil()
    {
        var windowField = typeof(Control).GetField("window", BindingFlags.Instance |
                                BindingFlags.NonPublic);
    
        Form notepad = new Form();
        NativeWindow window = (NativeWindow)windowField.GetValue(notepad);
        var process = Process.Start("notepad.exe");
        process.EnableRaisingEvents = true;
    
        while (process.MainWindowHandle == IntPtr.Zero)
        {
            Thread.Sleep(1);
        }
    
        window.AssignHandle(process.MainWindowHandle);
        Control.CheckForIllegalCrossThreadCalls = false;
    
        EventHandler handler = (s, ev) => notepad.DialogResult = DialogResult.OK;
        process.Exited += handler;
        notepad.ShowDialog(this);
        process.Exited -= handler;
        Control.CheckForIllegalCrossThreadCalls = true;
    }
