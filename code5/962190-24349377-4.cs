    private void button1_Click(object sender, EventArgs e)
    {
        UpdateStatusLabel("Started");
        Task.Factory.StartNew(() =>
        {
            // do some lengthy processing
            Thread.Sleep(10000);
            // no need to invoke here
            UpdateStatusLabel("Done");
        });
    }
