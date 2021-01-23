    foreach (string s in items)
    {
        ListViewItem lv = new ListViewItem();
        buffer = s.Split('/').ToArray<string>();
        lv.Text = items[0].ToString();
        for(int i=0; i<items.Count; i++)
        {
           lv.SubItems.Add(items[i].ToString());
        }
        listView1.Items.Add(lv);
        lv.Text = buffer[0];
        lv.SubItems.Add(buffer[1]);
        lv.SubItems.Add(buffer[2]);
        listView1.Items.Add(lv);
    }
