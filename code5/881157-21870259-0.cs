    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private const int HTCLIENT = 0x0001;
        private const int HTCAPTION = 0x0002;
        private const int WM_NCHITTEST = 0x0084;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if ((m.Msg == WM_NCHITTEST) & (m.Result.ToInt32() == HTCLIENT))
            {
                m.Result = (IntPtr)HTCAPTION;
            }
        }
    }
