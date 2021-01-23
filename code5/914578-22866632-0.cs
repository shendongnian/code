    ListViewItem item = new ListViewItem();
    line = reader.ReadLine();
    item.Text = line;           //set first column to name
    line = reader.ReadLine();
    item.SubItems.Add(line);
    line = reader.ReadLine();
    item.SubItems.Add(line);
    lsvHighscore.Items.Add(item); // add item to the list
