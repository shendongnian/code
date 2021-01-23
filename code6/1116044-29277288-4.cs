    public partial class Options_Form : Form
    {
        public Options_Form()
        {
            InitializeComponent();
        }
        private void Options_Load(object sender, EventArgs e)
        {
            AceMP_Class cl = new AceMP_Class();
            listBox1.Items.AddRange(cl.SupportedFiles_stringarray());
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            listBox1.Size = listBox1.PreferredSize;
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        public const uint KEYEVENTF_KEYUP = 0x02;
        public const uint VK_CONTROL = 0x11;
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(Convert.ToByte(VK_CONTROL), 0, 0, 0);
        }
        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            keybd_event(Convert.ToByte(VK_CONTROL), 0, Convert.ToByte(KEYEVENTF_KEYUP), 0);
        }
    }
