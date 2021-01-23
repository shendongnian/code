        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private PictureBox p;
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(p.Name);
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            p = ((ContextMenuStrip)sender).SourceControl as PictureBox;
        }
    }
