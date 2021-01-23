    public partial class Form2 : Form
    {
        private const int WM_ACTIVATE = 0x006;
        public Form2()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_ACTIVATE)
            {
                Console.WriteLine("Activate");
            }
            base.WndProc(ref m);
        }
    }
