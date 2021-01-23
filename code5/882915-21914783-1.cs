    public class SystemProcessHookForm : Form
    {
        private readonly int msgNotify;
        public delegate void EventHandler(object sender, string data);
        public event EventHandler WindowEvent;
        protected virtual void OnWindowEvent(string data)
        {
            var handler = WindowEvent;
            if (handler != null)
            {
                handler(this, data);
            }
        }
    
        public SystemProcessHookForm()
        {
            // Hook on to the shell
            msgNotify = Interop.RegisterWindowMessage("SHELLHOOK");
            Interop.RegisterShellHookWindow(this.Handle);
        }
    
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == msgNotify)
            {
                // Receive shell messages
                switch ((Interop.ShellEvents)m.WParam.ToInt32())
                {
                    case Interop.ShellEvents.HSHELL_WINDOWCREATED:
                    case Interop.ShellEvents.HSHELL_WINDOWDESTROYED:
                    case Interop.ShellEvents.HSHELL_WINDOWACTIVATED:
                        string wName = GetWindowName(m.LParam);
                        var action = (Interop.ShellEvents)m.WParam.ToInt32();
                        OnWindowEvent(string.Format("{0} - {1}: {2}", action, m.LParam, wName));
                        break;
                }
            }
            base.WndProc(ref m);
        }
    
        private string GetWindowName(IntPtr hwnd)
        {
            StringBuilder sb = new StringBuilder();
            int longi = Interop.GetWindowTextLength(hwnd) + 1;
            sb.Capacity = longi;
            Interop.GetWindowText(hwnd, sb, sb.Capacity);
            return sb.ToString();
        }
    
        protected override void Dispose(bool disposing)
        {
            try { Interop.DeregisterShellHookWindow(this.Handle); }
            catch { }
            base.Dispose(disposing);
        }
    }
