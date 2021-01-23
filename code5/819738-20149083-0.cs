    private void menuStrip1_ItemAdded(object sender, ToolStripItemEventArgs e)
    {
        if (e != null && e.Item != null && e.Item.GetType().Name == "SystemMenuItem")
        {
            this.menuStrip1.Items.RemoveAt(0);
        }
    }
