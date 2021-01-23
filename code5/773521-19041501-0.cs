    private Panel GetStatusPanel(string ip)
    {
        var result = new Panel();
        result.Controls.Add(new Label { Text = ip });
        Thread.Sleep(1000); // do the ping here, populate result panel accordingly
        return result;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        var ipList = new List<string> { "127.0.0.1", "192.168.0.1", "whatever" };
        statusFlowPanel.Controls.Clear();
        var tasks = ipList.Select(ip => new Task(() => 
            BeginInvoke((MethodInvoker)delegate
                {
                    statusFlowPanel.Controls.Add(GetStatusPanel(ip));
                    statusFlowPanel.Refresh();
                }))
            ).ToList();
        tasks.ForEach(t => t.Start());
    }
