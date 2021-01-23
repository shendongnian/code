    public partial class Form1 : Form
    {
        IList<string> files;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.files = new List<string>();
        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                files = Directory.EnumerateFiles(folderBrowserDialog.SelectedPath).ToList();
        }
    }
