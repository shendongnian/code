    Point p;
    if (GetCursorPos(out p))
    {
        IntPtr ptr = WindowFromPoint(p);
        if (ptr != IntPtr.Zero)
        {                    
            SetForegroundWindow(ptr);
            //wait for window to get focus quick and ugly
            // probably a cleaner way to wait for windows to send a message
            // that it has updated the foreground window
            await Task.Delay(300);
            //try to copy text in the current window
            SendKeys.Send("^c");
            await WaitForClipboardToUpdate(originalClipboardText);
       }
    }
    }
        private static async Task WaitForClipboardToUpdate(string originalClipboardText)
        {
            Stopwatch sw = Stopwatch.StartNew();
            while (true)
            {
                if (await DoClipboardCheck(originalClipboardText)) return;
                if (sw.ElapsedMilliseconds >= 1500) throw new Exception("TIMED OUT WAITING FOR CLIPBOARD TO UPDATE.");
            }
        }
        private static async Task<bool> DoClipboardCheck(string originalClipboardText)
        {
            await Task.Delay(10);
            if (!Clipboard.ContainsText()) return false;
            var currentText = Clipboard.GetText();
            Debug.WriteLine("current text: " + currentText + " original text: " + originalClipboardText);
            return currentText != originalClipboardText;
        }
       [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point pt);
        [DllImport("user32.dll", EntryPoint = "WindowFromPoint", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr WindowFromPoint(Point pt);
        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        
        [DllImportAttribute("user32.dll", EntryPoint = "GetForegroundWindow")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
