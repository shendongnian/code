    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_DEVICECHANGE = 0x0219;
            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    MessageBox.Show("Something changed.");
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
    }
