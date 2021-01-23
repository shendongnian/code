    //Must add using System.Runtime.InteropServices;
    public partial class Form1 : Form
    {
        [DllImport("user32")]
        private static extern IntPtr SetWinEventHook(int minEvent, int maxEvent, IntPtr hModule, WinEventProcDelegate proc, int procId, int threadId, int flags);
        private delegate void WinEventProcDelegate(IntPtr hHook, int ev, IntPtr hwnd, int objectId, int childId, int eventThread, int eventTime);
        private void WinEventProc(IntPtr hHook, int ev, IntPtr hwnd, int objectId, int childId, int eventThread, int eventTime)
        {
            if(hwnd != contextMenuStrip1.Handle) lastHandle = hwnd;
        }
        public Form1()
        {
            InitializeComponent();            
            //EVENT_SYSTEM_FOREGROUND = 3
            //WINEVENT_OUTOFCONTEXT = 0
            SetWinEventHook(3, 3, IntPtr.Zero, WinEventProc, 0, 0, 0);                                                                      
        }
        IntPtr lastHandle;
    }
    //You can access the lastHandle to get the current active/foreground window. This doesn't require GetForegroundWindow()
