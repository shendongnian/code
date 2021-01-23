    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string folder = e.Argument as string;
            // ...
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string folder = this.folderBrowserDialog1.SelectedPath;
                this.backgroundWorker1.RunWorkerAsync(folder);
            }
        }
    }
