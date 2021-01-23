    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        const int WM_KEYUP = 0x0101;
        const int WM_KEYDOWN = 0x0100;
        protected override bool ProcessKeyPreview(ref Message m)
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
            return base.ProcessKeyPreview(ref m);
        }
    }
