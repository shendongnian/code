    private void listView1_MouseMove(object sender, MouseEventArgs e)
    {
        if (r.Contains(e.Location))
            return;
        int columnIndex = getColumnIndex(e.Location);
        if (columnIndex == 3)
            listView1.Cursor = Cursors.Hand;
        else
            listView1.Cursor = Cursors.Default;
    }
    Rectangle r = Rectangle.Empty;
    private int getColumnIndex(Point p)
    {
        r = Rectangle.Empty;
        for (int i = 0; i < listView1.Columns.Count; i++)
        {
            r = new Rectangle(r.X + r.Width, 0, listView1.Columns[i].Width, listView1.Height);
            if (r.Contains(p))
                return i;
        }
        return -1;
    }
