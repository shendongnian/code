        public Form1()
        {
            InitializeComponent();
           
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke((Action)(() =>
                            {
                                var form2 = new Form2();
                                form2.Show();
                            }));
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
