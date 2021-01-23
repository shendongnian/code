    private void Starter_Click(object sender, EventArgs e)
    {
            Task<bool> taskA = new Task<bool>(() => { return IsValid(); });
            taskA.ContinueWith((ss) =>
            {
                if (ss.Result)
                {
                    MessageBox.Show("Showing Window");
                }
            });
            taskA.Start();
    }
    private bool IsValid()
    {
            System.Threading.Thread.Sleep(5000);
            return true;
    }
