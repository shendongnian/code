    using System;
    using System.Threading;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    public enum AppCommands {
        BrowserBack = 1,
        BrowserForward = 2,
        BrowserRefresh = 3,
        BrowserStop = 4,
        BrowserSearch = 5,
        BrowserFavorite = 6,
        BrowserHome = 7,
        VolumeMute = 8,
        VolumeDown = 9,
        VolumeUp = 10,
        MediaNext = 11,
        MediaPrevious = 12,
        MediaStop = 13,
        MediaPlayPause = 14,
        LaunchMail = 15,
        LaunchMediaSelect = 16,
        LaunchApp1 = 17,
        LaunchApp2 = 18,
        BassDown = 19,
        BassBoost = 20,
        BassUp = 21,
        TrebleUp = 22,
        TrebleDown = 23,
        MicrophoneMute = 24,
        MicrophoneVolumeUp = 25,
        MicrophoneVolumeDown = 26,
        Help = 27,
        Find = 28,
        New = 29,
        Open = 30,
        Close = 31,
        Save = 32,
        Print = 33,
        Undo = 34,
        Redo = 35,
        Copy = 36,
        Cut = 37,
        Paste = 38,
        ReplyToMail = 39,
        ForwardMail = 40,
        SendMail = 41,
        SpellCheck = 42,
        Dictate = 43,
        MicrophoneOnOff = 44,
        CorrectionList = 45,
        MediaPlay = 46,
        MediaPause = 47,
        MediaRecord = 48,
        MediaFastForward = 49,
        MediaRewind = 50,
        MediaChannelUp = 51,
        MediaChannelDown = 52,
        Delete = 53,
        Flip3D = 54
    }
    
    public static class AppCommand {
        public static void Send(AppCommands cmd) {
            if (frm == null) Initialize();
            frm.Invoke(new MethodInvoker(() => SendMessage(frm.Handle, WM_APPCOMMAND, frm.Handle, (IntPtr)((int)cmd << 16))));
        }
    
        private static void Initialize() {
            // Run the message loop on another thread so we're compatible with a console mode app
            var t = new Thread(() => {
                frm = new Form();
                var dummy = frm.Handle; 
                frm.BeginInvoke(new MethodInvoker(() => mre.Set()));
                Application.Run();
            });
            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();
            mre.WaitOne();
        }
        public static void Cleanup() { 
            if (frm != null) {
                frm.BeginInvoke(new MethodInvoker(() => { 
                    frm.Close();
                    Application.ExitThread();
                    mre.Set(); 
                }));
                mre.WaitOne();
                frm = null;
            }
        }
    
        private static ManualResetEvent mre = new ManualResetEvent(false);
        private static Form frm;
    
        // Pinvoke
        private const int WM_APPCOMMAND = 0x319;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
