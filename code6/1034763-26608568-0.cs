    foreach (string name in key.GetValueNames())
    {
        string value = key.GetValue(name).ToString();
        ListViewItem item = new ListViewItem( new string[] { name, value } );
        listView1.Items.Add(item);
    }
