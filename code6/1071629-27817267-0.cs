    public class BlockingForm : Form
    {
        public delegate void SessionEnd();
        public event SessionEnd SessionEndEvent;
        public BlockingForm()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }
        protected override void WndProc(ref Message aMessage)
        {
            const int WM_QUERYENDSESSION = 0x0011;
            const int WM_ENDSESSION = 0x0016;
            if (aMessage.Msg == WM_QUERYENDSESSION || aMessage.Msg == WM_ENDSESSION)
            {
                OnSessionEnd();
            }
            base.WndProc(ref aMessage);
        }
        private void OnSessionEnd()
        {
            var handler = SessionEndEvent;
            if (handler != null) handler();
        }
    }
