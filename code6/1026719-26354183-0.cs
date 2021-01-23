    private void dcash(object sender, EventArgs e)
    {
        ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
        List<string> path = new List<string>();
        path.Add(tsmi.Name);
        while (tsmi.OwnerItem.GetType() != typeof(ToolStrip))
        {
             tsmi = (ToolStripMenuItem)tsmi.OwnerItem;
             path.Add(tsmi.Name);
        }
    }
