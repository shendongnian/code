    HighLight f = new HighLight() { BackColor = Color.Red };
    private void splitter1_SplitterMoving(object sender, SplitterEventArgs e)
    {
        this.splitter1.Parent.Refresh();
        f.Location = this.splitter1.Parent.PointToScreen(new Point(e.SplitX, e.SplitY));
        f.Size = this.splitter1.Size;
        if (!f.Visible)
            f.ShowInactiveTopmost();
    }
    private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
    {
        f.Hide();
    }
