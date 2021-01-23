    private async void Form1_Load(object sender, EventArgs e)
    {
        byte[] buffer = Encoding.ASCII.GetBytes(".");
        PingOptions options = new PingOptions(50, true);
        AutoResetEvent reset = new AutoResetEvent(false);
        Ping ping = new Ping();
        ping.PingCompleted += new PingCompletedEventHandler(ping_Complete);
        
        var tasks = List<Task>();
        foreach (TreeNode node in treeView1.Nodes)
        {
            var task = PingAndUpdateNodeAsync(ping, node);
            tasks.Add(task);
        }
        
        await Task.WhenAll(tasks);
    }
    
    private async Task PingAndUpdateNodeAsync(Ping ping, TreeNode node)
    {
        var reply = await ping.SendPingAsync(node.Text, 5000, buffer, options, reset);
        if (reply.Status == IPStatus.Success)
        {
            node.Text = node.Text + " (OK)";
        }
        else
        {
            node.Text = node.Text + " (FAILED)";
        }
    }
