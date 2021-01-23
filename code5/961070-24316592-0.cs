    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }
        const int WM_KEYUP = 0x0101;
        const int WM_KEYDOWN = 0x0100;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_KEYDOWN:
                    Console.WriteLine(m.LParam);
                    break;
                case WM_KEYUP:
                    Console.WriteLine(m.LParam);
                    break;
            }
            base.WndProc(ref m);
        }
    }
