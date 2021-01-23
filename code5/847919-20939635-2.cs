    foreach (var rssItem in items)
    {
         ListViewItem item  = new ListViewItem();
         item.Text = rssItem.Title;
         item.Tag = rssItem;
         listView1.Items.Add(item);
     }
