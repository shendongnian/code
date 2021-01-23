    public partial class Form1 : Form
    {
        private BackgroundWorker bg;
        public Form1()
        {
            InitializeComponent();
            bg = new BackgroundWorker
                 {
                     WorkerSupportsCancellation = true
                 };
            bg.DoWork += (sender, args) =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                    if (bg.CancellationPending)
                        break;
                }
                MessageBox.Show("Done!");
            };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bg.CancelAsync();
        }
    }
