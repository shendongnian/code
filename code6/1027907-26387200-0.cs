    public class DataGridViewEx : DataGridView
    {
        public bool IsUserScrolling { get; set; }
        private const int WM_HSCROLL = 0x0114;
        private const int WM_VSCROLL = 0x0115;
        private const int SB_ENDSCROLL = 8;
        public event EventHandler UserScrollComplete;
        protected virtual void OnUserScrollComplete()
        {
            EventHandler handler = UserScrollComplete;
            if (handler != null) handler(this, EventArgs.Empty);
        }
        protected override void WndProc(ref Message m)
        {
            // http://msdn.microsoft.com/en-us/library/windows/desktop/bb787575(v=vs.85).aspx
            // http://msdn.microsoft.com/en-us/library/windows/desktop/bb787577(v=vs.85).aspx
            if ((m.Msg == WM_HSCROLL) ||
                (m.Msg == WM_VSCROLL))
            {
                
                short loword = (short)(m.WParam.ToInt32() & 0xFFFF);
                if (loword == SB_ENDSCROLL)
                {
                    IsUserScrolling = false;
                    OnUserScrollComplete();
                }
                else
                {
                    IsUserScrolling = true;
                }
            }
            base.WndProc(ref m);
        }
    }
