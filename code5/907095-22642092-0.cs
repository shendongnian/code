     public static class User32_DLL
    {
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }
        protected override void OnNotifyMessage(Message m)
        {
            const int WM_MOVING = 0x0216;
            if (m.Msg == WM_MOVING)
            {
                if (Control.ModifierKeys == Keys.Control)
                {
                    User32_DLL.ReleaseCapture();
                }
            }
            base.OnNotifyMessage(m);
        }
    }
