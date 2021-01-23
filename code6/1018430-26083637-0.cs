    var lines = File.ReadAllLines(filename);
    foreach (string line in lines)
    {
        var parts = line.Split(',');
        ListViewItem lvi = new ListViewItem(parts[0]);
        lvi.SubItems.Add(parts[1]);
        listView1.Items.Add(lvi);
    }
