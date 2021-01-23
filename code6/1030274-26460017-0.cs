    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int pointerCode = Marshal.ReadInt32(lParam);
            string pressedKey = ((Keys)pointerCode).ToString();
            //Do some sort of processing on key press
            var thread = new Thread(() => 
            {   MessageBox.Show(pressedKey);
                if (pressedKey.Equals("Space") || pressedKey.Equals("Tab"))
                    {
                        ***Word.Range rng = this.Application.ActiveDocument.Words.Last;
                        rng.Select();
                        rng.Copy();
                        String input = Clipboard.GetText(TextDataFormat.Text);
                    }               
            });
            thread.Start();
        }
        return CallNextHookEx(hookId, nCode, wParam, lParam);
    }
