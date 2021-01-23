    protected override void WndProc(ref Message m)
    {
        Boolean handled = false;
        if (m.Msg == NativeCalls.APIAttach && (uint)m.Param == NativeCalls.SKYPECONTROLAPI_ATTACH_SUCCESS)
        {
            // Get the current handle to the Skype window
            NativeCalls.HWND_BROADCAST = m.WParam;
            handled = true;
            m.Result = new IntPtr(1);
        }
    
        // Skype sends our program messages using WM_COPYDATA. the data is in lParam
        if (m.Msg == NativeCalls.WM_COPYDATA && m.WParam == NativeCalls.HWND_BROADCAST)
        {
            COPYDATASTRUCT data = (COPYDATASTRUCT)Marshal.PtrToStructure(lParam, typeof(COPYDATASTRUCT));
            StatusTextBox.AppendText(data.lpData + Environment.NewLine);
    
            // Check for connection
            if (data.lpData.IndexOf("CONNSTATUS ONLINE") > -1)
                ConnectButton.IsEnabled = false;
    
            // Check for calls
            IsCallInProgress(data.lpData);
            handled = true;
            m.Result = new IntPtr(1);
        }
    
        m.Result = IntPtr.Zero;
        if (handled) DefWndProc(ref m); else base.WndProc(ref m);
    }
