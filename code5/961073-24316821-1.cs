    public partial class Form1 : Form, IMessageFilter {  // NOTE: added IMessageFilter
        public Form1() {
            InitializeComponent();
            Application.AddMessageFilter(this);
        }
        protected override void OnFormClosed(FormClosedEventArgs e) {
            Application.RemoveMessageFilter(this);
            base.OnFormClosed(e);
        }
        bool IMessageFilter.PreFilterMessage(ref Message m) {
            // Trap WM_KEYUP/DOWN for Keys.Down key
            if ((m.Msg == 0x100 || m.Msg == 0x101) && (Keys)m.WParam.ToInt32() == Keys.Down) {
                bool repeat = (m.LParam.ToInt32() & (1 << 30)) != 0;
                bool down = m.Msg == 0x100;
                // But only for this form
                Form form = null;
                var ctl = Control.FromHandle(m.HWnd);
                if (ctl != null) form = ctl.FindForm();
                if (form == this) {
                    OnCursorDown(down, repeat & down);
                    return true;
                }
            }
            return false;
        }
        private void OnCursorDown(bool pressed, bool repeat) {
            // etc..
        }
    }
