    private void button1_Click(object sender, EventArgs e)
    {
        System.ComponentModel.BackgroundWorker bw = new System.ComponentModel.BackgroundWorker();
        bw.DoWork += (sender, e) => 
        {
            string st = "hello my name is miroslav glamuzina";
            string[] arr = st.Split(' ');
            System.ComponentModel.BackgroundWorker worker = sender as System.ComponentModel.BackgroundWorker;
            for (int i = 0; i < arr.Length; i++)
            {                
                Thread.Sleep(500);
                worker.ReportProgress(i, arr[i]);
            }
        };
        bw.ProgressChanged += (sender, e) =>
        {
            label1.Text = e.UserState as string;
        };
        bw.RunWorkerAsync();
    }
