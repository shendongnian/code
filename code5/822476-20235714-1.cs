    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84) //WM_NCHITTEST = 0x84
            {
                int x = m.LParam.ToInt32() & 0xffff;
                int y = m.LParam.ToInt32() >> 16;
                int codex, codey;
                Point p = PointToClient(new Point(x, y));
                codey = p.Y < 5 ? 2 : p.Y > ClientSize.Height - 5 ? 1 : 0;
                codex = p.X < 5 ? 2 : p.X > ClientSize.Width - 5 ? 1 : 0;
                switch (codex + (codey<<2))
                {
                    case 10://Top-Left
                        m.Result = (IntPtr)13;
                        return;
                    case 8://Top
                        m.Result = (IntPtr)12;
                        return;
                    case 9://Top-Right
                        m.Result = (IntPtr)14;
                        return;
                    case 2://Left
                        m.Result = (IntPtr)10;
                        return;
                    case 1://Right
                        m.Result = (IntPtr)11;
                        return;
                    case 6://Bottom-Left
                        m.Result = (IntPtr)16;
                        return;
                    case 4://Bottom
                        m.Result = (IntPtr)15;
                        return;
                    case 5://Bottom-Right;
                        m.Result = (IntPtr)17;
                        return;
                }                
            }
            base.WndProc(ref m);
        }
    }
