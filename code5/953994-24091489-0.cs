    private int getcolumn()
    {
        Point mousePosition = base.PointToClient(Control.MousePosition);
        ListViewHitTestInfo hit = base.HitTest(mousePosition);   
        if Item.SubItems.Any()
        {
        return hit.Item.SubItems.IndexOf(hit.SubItem);
        }
        else
        {
        return -1; 
        }
    }
