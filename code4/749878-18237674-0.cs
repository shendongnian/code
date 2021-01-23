    public partial class Form1 : Form, IMessageFilter {
        public Form1() {
            InitializeComponent();
            Application.AddMessageFilter(this);
        }
        protected override void OnFormClosed(FormClosedEventArgs e) {
            Application.RemoveMessageFilter(this);
            base.OnFormClosed(e);
        }
        public bool PreFilterMessage(ref Message m) {
            // Trap WM_SYSKEYUPDOWN message for the ALT key
            if ((Keys)m.WParam.ToInt32() == Keys.Menu) {
                if (m.Msg == 0x104) { AltKeyPressed = true; return true; }
                if (m.Msg == 0x105) { AltKeyPressed = false; return true; }
            }
            return false;
        }
        private bool AltKeyPressed;
    }
