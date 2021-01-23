    private void FillListView()
    {
        listView1.ShowItemToolTips = true;
        ListViewItem item1 = new ListViewItem("Item 1");
        item1.ToolTipText = item1.Text;
        listView1.Items.Add(item1);
        ListViewItem item2 = new ListViewItem("Item 2");
        item2.ToolTipText = item2.Text;
        listView1.Items.Add(item2);
        ListViewItem item3 = new ListViewItem("Item 3");
        item3.ToolTipText = item3.Text;
        listView1.Items.Add(item3);
    }
