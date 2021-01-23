    private Point LastMousePos = new Point(-1, -1);
    
    private void treeListView1_MouseMove(object sender, MouseEventArgs e)
    {
        if (LastMousePos == e.Location)
            return;
        ListViewItem item = treeListView1.GetItemAt(e.X, e.Y);
        ListViewHitTestInfo info = treeListView1.HitTest(e.X, e.Y);
        if ((item != null) && (info.SubItem != null))
        {
            LastMousePos = e.Location;
            toolTip1.Show(info.SubItem.Text, this.treeListView1);
        }
        else
        {
            toolTip1.Hide(this.treeListView1);
        }
    }
