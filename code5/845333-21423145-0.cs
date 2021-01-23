    public static IntPtr getHWnd(string title)
        {
            IntPtr hWnd = FindWindow(null, title);
            BringWindowToTop(hWnd);
            SetActiveWindow(hWnd);
            SetForegroundWindow(hWnd);
            Thread.Sleep(500);
            foreach (Process process in Process.GetProcessesByName("IExplore"))
            {
                if (process.MainWindowTitle.ToLower().Contains(title.ToLower()))
                {
                    hWnd = process.MainWindowHandle;
                    break;
                }
            }
            EnumProc proc = new EnumProc(EnumWindows);
            EnumChildWindows(hWnd, proc, ref hWnd);
            return hWnd;
        }
        public HTMLDocument GetHTMLDocument(IntPtr hWnd)
        {
            HTMLDocument document = null;
            int iMsg = 0;
            int iRes = 0;
            iMsg = RegisterWindowMessage("WM_HTML_GETOBJECT");
            if (iMsg != 0)
            {
                SendMessageTimeout(hWnd, iMsg, 0, 0, SMTO_ABORTIFHUNG, 1000, out iRes);
                if (iRes != 0)
                {
                    int hr = ObjectFromLresult(iRes, ref IID_IHTMLDocument, 0, ref document);
                }
            }
            return document;
        }
        private static int EnumWindows(IntPtr hWnd, ref IntPtr lParam)
        {
            int iRet = 1;
            StringBuilder classname = new StringBuilder(128);
            GetClassName(hWnd, classname, classname.Capacity);
            if ((bool)(string.Compare(classname.ToString(), "Internet Explorer_Server") == 0))
            {
                lParam = hWnd;
                iRet = 0;
            }
            return iRet;
        }
