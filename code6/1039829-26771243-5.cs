    private int getRowIndex(Point p)
    {
        Rectangle r = Rectangle.Empty;
        for (int i = 0; i < listView1.Items.Count; i++)
        {
            Rectangle r1 = listView1.GetItemRect(i);
            r = new Rectangle(0, r1.Top, listView1.Width, r1.Height);
            if (r.Contains(p))
            {
                listView1.FocusedItem = listView1.Items[i];
                return i;
            }
        }
        return -1;
    }
