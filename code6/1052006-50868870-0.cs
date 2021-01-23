        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);   
        private const int SW_SHOWMAXIMIZE = 3; 
 
        public void Display()
        {
            message = RedemptionLoader.new_SafeMailItem();
            message.Item = mailApp.CreateItem(Outlook.OlItemType.olMailItem);
            Process proc = Process.GetProcessesByName("outlook").FirstOrDefault();
            if (proc != null)
            {
                ShowWindow(proc.MainWindowHandle, SW_SHOWMAXIMIZE);   
                SetForegroundWindow(proc.MainWindowHandle);         
            }
            ((Outlook.MailItem)message.Item).Display(false);	// Show email to user, false = Non-Modal
            
        }
