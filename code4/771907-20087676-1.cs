    void AppCommand(AppComandCode commandCode)
    {
        int CommandID = (int)commandCode << 16;
        SendMessageW(Process.GetCurrentProcess().MainWindowHandle, WM_APPCOMMAND, Process.GetCurrentProcess().MainWindowHandle, (IntPtr)CommandID);
    }
