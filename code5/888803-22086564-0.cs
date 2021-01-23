    string[] items = listView1.Items.Cast<ListViewItem>().Where(s => s.Text == "Apple" || s.Text == "Banana").
                                                          Select(s => s.Text).ToArray();
    foreach (string item in items)
    {
        Console.WriteLine(item);
    }
