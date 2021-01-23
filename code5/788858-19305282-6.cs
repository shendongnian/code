    private void button1_Click(object sender, EventArgs e)
    {
        status.Text = "In Progress";
        if (listBox1.Items.Count == 0)
        {
            MessageBox.Show("Please select a file to upload");
        }
        string fileName = getFileNameFromPath(listBox1.Items[0].ToString());
        string localFile = listBox1.Items[0].ToString();
        string remoteFile = "**********/" + fileName;
        var worker = new BackgroundWorker();
        worker.DoWork += (s, args) =>
        {
            FtpClient client = new FtpClient("*******", "*******", "******");
            args.Result =  client.upload(remoteFile, localFile);
        };
        worker.RunWorkerCompleted += (s, args) =>
        {
            listBox1.Items.RemoveAt(0);
            textBox1.Text = args.Result as string;
            status.Text = "Ready";
        };
        worker.RunWorkerAsync();
    }
