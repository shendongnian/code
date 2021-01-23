    foreach (ListViewItem item in listView.Items)
    {
          totalSessionTime += TimeSpan.Parse(item.SubItems[1].Text);
          totalIdleTime += TimeSpan.Parse(item.SubItems[2].Text);
          totalActiveTime += TimeSpan.Parse(item.SubItems[2].Text);
    }
