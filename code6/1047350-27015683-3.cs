    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        e.DrawBackground();
        e.DrawText();
        if (e.Item.Selected)
        {
            Rectangle R = e.Bounds;  
            R.Inflate(-1, -1);
            using (Pen pen = new Pen(Color.Red, 1.5f))
            e.Graphics.DrawRectangle(pen, R);
        }
    }
