    public void OnMouseUp(Object sender, MouseEventArgs e)
    {
        ListViewHitTestInfo htInfo = listView1.HitTest(e.Location);
        if (htInfo.Item != null)
             //display your menu
    }
