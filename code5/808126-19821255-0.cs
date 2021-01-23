    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Form2 f2 = null;
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f2 == null || f2.IsDisposed)
            {
                f2 = new Form2();
                f2.MdiParent = this;
                f2.Show();
            }
            else
            {
                if (f2.WindowState == FormWindowState.Minimized)
                {
                    f2.WindowState = FormWindowState.Normal;
                }
                f2.Activate();
            }
        }
    }
