    public Form1()
    {
        InitializeComponent();
        progressBar1.Minimum = 0;
        progressBar1.Maximum = 5;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    progressBar1.BeginInvoke((Action)(() =>
                        {
                            progressBar1.Value = i;
                        }));
                    Thread.Sleep(250);
                }
            });
    }
