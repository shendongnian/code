    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Opacity = 0; // prevent ALT-TAB preview
            this.WindowState = FormWindowState.Minimized;
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_RESTORE = 0xF120;
            const int SC_MAXIMIZE = 0xF030;
            if ((m.Msg == WM_SYSCOMMAND) && ((int)m.WParam == SC_RESTORE || (int)m.WParam == SC_MAXIMIZE))
            {
                return;
            }
            base.WndProc(ref m);
        }
    }
