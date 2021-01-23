    for (int i = 0; i < lines.Count; i+=2)
    {
       ListViewItem item = new ListViewItem();
       item.Text= lines[i];
       item.SubItems.Add(lines[i+1]);
       listView1.Items.Add(item);
    }
