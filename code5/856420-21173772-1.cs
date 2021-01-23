    public void OnMouseUp(Object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            ListViewHitTestInfo htInfo = listView1.HitTest(e.Location);
            if (htInfo.Item != null)
                //display your menu
        }
    }
