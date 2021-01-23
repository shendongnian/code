    private async void button1_Click(object sender, EventArgs e)
    {
        status.Text = "In Progress";
        if (listBox1.Items.Count == 0)
        {
            MessageBox.Show("Please select a file to upload");
        }
        FtpClient client = new FtpClient("*******", "*******", "******");
        string fileName = getFileNameFromPath(listBox1.Items[0].ToString());
        string localFile = listBox1.Items[0].ToString();
        string remoteFile = "**********/" + fileName;
        string link = await Task.Run(() => client.upload(remoteFile, localFile));
        listBox1.Items.RemoveAt(0);
        textBox1.Text = link;
        status.Text = "Ready";
    }
