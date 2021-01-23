    private delegate void showProgressCallBack(int value);
    private void btnStart5_Click(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            Loading f = new Loading();
            f.Show();
            bw.DoWork += (s, ea) =>
            {
                try
                {
                    test1();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message); 
                }
            };
            bw.RunWorkerCompleted += (s, ea) =>
            {
                f.Close();
            };
            bw.RunWorkerAsync();
        }
----------
    private void showProgress(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                showProgressCallBack showProgressDelegate =  new showProgressCallBack(showProgress);
                this.Invoke(showProgressDelegate, new object[] {value});
            }
            else
            {
                progressBar1.Value = value;
            }
        }
