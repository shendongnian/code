    private async void Form1_Load(object sender, EventArgs e)
    {
        byte[] buffer = Encoding.ASCII.GetBytes(".");
        PingOptions options = new PingOptions(50, true);
        AutoResetEvent reset = new AutoResetEvent(false);
        Ping ping = new Ping();
        ping.PingCompleted += new PingCompletedEventHandler(ping_Complete);
        
        var tasks = new Dictionary<TreeNode, Task<PingReply>>();
        foreach (TreeNode node in treeView1.Nodes)
        {
            var task = ping.SendPingAsync(node.Text, 5000, buffer, options, reset);
            tasks.Add(node, task);
        }
        
        await Task.WhenAll(tasks);
        foreach(var e in tasks)
        {
            var node = e.Key;
            var task = e.Value;
            var reply = await task; // you could also use task.Result, since the task is already complete at this point
            if (reply.Status == IPStatus.Success)
            {
                node.Text = node.Text + " (OK)";
            }
            else
            {
                node.Text = node.Text + " (FAILED)";
            }
        }
    }
