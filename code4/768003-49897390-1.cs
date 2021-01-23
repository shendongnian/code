    class Service
    {
        [DllImport("wtsapi32.dll", SetLastError = true)]
        static extern bool WTSSendMessage(
                IntPtr hServer,
                [MarshalAs(UnmanagedType.I4)] int SessionId,
                String pTitle,
                [MarshalAs(UnmanagedType.U4)] int TitleLength,
                String pMessage,
                [MarshalAs(UnmanagedType.U4)] int MessageLength,
                [MarshalAs(UnmanagedType.U4)] int Style,
                [MarshalAs(UnmanagedType.U4)] int Timeout,
                [MarshalAs(UnmanagedType.U4)] out int pResponse,
                bool bWait);
        public static IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;
        public static int WTS_CURRENT_SESSION = 1;
        public void Start()
        {
            for (int user_session = 10; user_session>0; user_session--)
            {
                Thread t = new Thread(() => {
                    try
                    {                        
                        bool result = false;
                        String title = "Alert";
                        int tlen = title.Length;
                        String msg = "hi";
                        int mlen = msg.Length;
                        int resp = 7;
                        result = WTSSendMessage(WTS_CURRENT_SERVER_HANDLE, user_session, title, tlen, msg, mlen, 4, 0, out resp, true);
                        int err = Marshal.GetLastWin32Error();
                        if (err == 0)
                        {
                            Debug.WriteLine("user_session:" + user_session + " err:" + err + " result:" +result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("no such thread exists", ex);
                    }
                    //Application App = new Application();
                    //App.Run(new MessageForm());
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
        }
        public void Stop()
        {
            // write code here that runs when the Windows Service stops.  
        }
    }
