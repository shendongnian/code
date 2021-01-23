    async void contexMenuuu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        var item = ... something here?;
        var label = ... and something here?;
        if (item.Text == "Acknowledge")
        {
            label.Text = "NO";
            await Task.Delay(TimeSpan.FromMinutes(5));
            label.Text = "YES";
        }
    }
