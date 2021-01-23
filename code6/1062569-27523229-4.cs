    private void PingCompleted(object sender, PingCompletedEventArgs e)
    {
        string ip = (string)e.UserState;
        if (e.Reply != null && e.Reply.Status == IPStatus.Success)
        {
            // Logic for Ping Reply Success
            ListViewItem item = new ListViewItem(ip);
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => 
                {
                    lstLocal.Items.Add(item);
                }));
            }
            else
            {
                lstLocal.Items.Add(item);
            }
            // Logic for Ping Reply Success
            // Console.WriteLine(String.Format("Host: {0} ping successful", ip));
        }
        else
        {
            // Logic for Ping Reply other than Success
        }
    }
