    public async void PingThings()
    {
        // executing in thread
        lstLocal.FullRowSelect = true;
        var tasks = Enumerable.Range(0, 3)
            .Select(i => new Ping().SendPingAsync("192.168.1" + "." + i));
        var replies = await Task.WhenAll(tasks);
        foreach (var reply in replies.Where(reply => reply.Status == IPStatus.Success))
            lstLocal.Items.Add(new ListViewItem(reply.Address.ToString()));
    }
