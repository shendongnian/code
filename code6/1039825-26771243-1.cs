    private int getColumnIndex(Point p)
    {
        Rectangle r = Rectangle.Empty;
        r = Rectangle.Empty;
        for (int i = 0; i < listView1.Columns.Count; i++)
        {
            r = new Rectangle(r.X + r.Width, 0, listView1.Columns[i].Width, listView1.Height);
            if (r.Contains(p))            
                return i;
        }
        return -1;
    }
