    public partial class Form1 : Form
    {
        private delegate DialogResult ShowFolderBrowser();
        public Form1()
        {
            InitializeComponent();
        }
        private DialogResult ShowFolderBrowserDialog()
        {
            return this.folderBrowserDialog1.ShowDialog();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((DialogResult)this.Invoke(this.ShowFolderBrowserDialog) == DialogResult.OK)
            {
                // ...
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync();
        }
    }
