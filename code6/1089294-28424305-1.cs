    void contexMenuuu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        var item = ... something here?;
        var label = ... and something here?;
        if (item.Text == "Acknowledge")
        {
            label.Text = "NO";
    
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += (sender, e) => Invoke((MethodInvoker)(() => label.Text = "YES"));
            aTimer.Interval = TimeSpan.FromMinutes(5).TotalMilliseconds;
            aTimer.Enabled = true;
        }
    }
