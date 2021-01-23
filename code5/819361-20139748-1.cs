    var itemFound = false;
    foreach (var listViewItem in lvSales.Items)
    {
        if (listViewItem.SubItems[0].Text == btn.Text)
        {
            itemFound = true; break;
        }
    }
    if (!itemFound)
    {
        var newlistViewItem = new ListViewItem();
        newlistViewItem.Text = count.ToString();
        newlistViewItem.SubItems.Add(btn.Text);
        newlistViewItem.SubItems.Add(btn.Name);
        newlistViewItem.SubItems.Add(count.ToString());
        newlistViewItem.SubItems.Add(btn.Tag.ToString()); // Email  
        lvSales.Items.Add(lvis);
    }
