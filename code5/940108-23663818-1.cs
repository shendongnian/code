    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const int GWL_EXSTYLE = -20;
        const int WS_EX_TRANSPARENT = 0x20;
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        extern static int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static int SetWindowLong(IntPtr hWnd, int nIndex, int nStyle);
        private void Form1_Load(object sender, EventArgs e)
        {
            var style = GetWindowLong(this.Handle, GWL_EXSTYLE);
            var newStyle = style | WS_EX_TRANSPARENT;
            SetWindowLong(this.Handle, GWL_EXSTYLE, newStyle);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
