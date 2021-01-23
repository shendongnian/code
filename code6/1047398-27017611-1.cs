    private void button1_Click(object sender, EventArgs e)
    {
        progressBar1.Minimum = 0;
        progressBar1.Maximum = 5;
        Task.Factory.StartNew(() =>
            {
                for (int i = 0; i <= 5; i++)
                {
                    int progress = i;
                    progressBar1.BeginInvoke((Action)(() =>
                        {
                            progressBar1.Value = progress;
                        }));
                    Thread.Sleep(250);
                }
            });
    }
