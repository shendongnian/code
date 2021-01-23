    private void listView1_MouseMove(object sender, MouseEventArgs e)
    {
        int columnIndex = getColumnIndex(e.Location);
        if (columnIndex == 3)
            listView1.Cursor = Cursors.Hand;
        else
            listView1.Cursor = Cursors.Default;
    }
    private int getColumnIndex(Point p)
    {
        Rectangle r = Rectangle.Empty;
        for (int i = 0; i < listView1.Columns.Count; i++)
        {
            r = new Rectangle(r.X + r.Width, 0, listView1.Columns[i].Width, listView1.Height);
            if (r.Contains(p))
                return i;
        }
        return -1;
    }
