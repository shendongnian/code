    // Call DoWork like this:
    backgroundWorker1.RunWorkerAsync(new Tuple<string, int, int>(host, startPort, endPort));
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        Tuple<string, int, int> portRange = e.Argument as Tuple<string, int, int>;
        for (int i = portRange.Item2; i <= portRange.Item3; i++)
        {
            using (var tcp = new System.Net.Sockets.TcpClient())
            {
                try
                {
                    tcp.SendTimeout = 500;
                    tcp.ReceiveTimeout = 500;
                    tcp.Connect(portRange.Item1, i);
                    this.Invoke((Action)delegate()
                    {
                        richTextBox1.Text += "Port " + i + " Is Opened" + System.Environment.NewLine;
                    });
                }
                catch
                {
                    this.Invoke((Action)delegate()
                    {
                        richTextBox1.Text += "Connection Refused On Port " + i + System.Environment.NewLine;
                    });
                }
            }
        }
