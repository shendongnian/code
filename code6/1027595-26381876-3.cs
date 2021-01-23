    private void btnGetBrowserProcess_Click(object sender, EventArgs e)
    {
            Process[] procsChrome = Process.GetProcessesByName("chrome");
            foreach (Process chrome in procsChrome)
            {
                if (chrome.MainWindowHandle != IntPtr.Zero)
                {
                    // Set focus on the window so that the key input can be received.
                    SetForegroundWindow(chrome.MainWindowHandle);
                    // Create a F5 key press
                    INPUT ip = new INPUT { Type  =1};
                    ip.Data.Keyboard = new KEYBDINPUT();
                    ip.Data.Keyboard.Vk = (ushort)0x74;  // F5 Key
                    ip.Data.Keyboard.Scan = 0;
                    ip.Data.Keyboard.Flags = 0;
                    ip.Data.Keyboard.Time = 0;
                    ip.Data.Keyboard.ExtraInfo = IntPtr.Zero;
                    var inputs = new INPUT[] { ip };
                    
                    // Send the keypress to the window
                    SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
                    // probably need to set focus back to your application here.
                }
            }
    }
