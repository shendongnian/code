    var listViewItem = lvSales.Items.Where(lvi => lvi.SubItems[0].Text == btn.Text).FirstOrDefault;
    if (listViewItem == null)
    {
        var newlistViewItem = new ListViewItem();
        newlistViewItem.Text = count.ToString();
        newlistViewItem.SubItems.Add(btn.Text);
        newlistViewItem.SubItems.Add(btn.Name);
        newlistViewItem.SubItems.Add(count.ToString());
        newlistViewItem.SubItems.Add(btn.Tag.ToString()); // Email  
        lvSales.Items.Add(lvis);
    }
