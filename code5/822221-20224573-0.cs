    List<string> sList = new List<string>() { "1", "2", "3", "4", "5" };
    List<string> lList = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" };
    private void button1_Click(object sender, EventArgs e)
    {
        listView1.Clear();
        addColumns();
        for (int i = 0; i < sList.Count(); i++)
        {
            var item1 = new ListViewItem(sList[i]);
            item1.SubItems.Add(String.Empty);
            item1.SubItems.Add(String.Empty);
            listView1.Items.Add(item1);
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        listView1.Clear();
        addColumns();
        for (int i = 0; i < lList.Count(); i++)
        {
            if (i < sList.Count())
            {
                var item2 = new ListViewItem(sList[i]);
                item2.SubItems.Add(lList[i]);
                item2.SubItems.Add(String.Empty);
                listView1.Items.Add(item2);
            }
            else
            {
                var item3 = new ListViewItem(String.Empty);
                item3.SubItems.Add(lList[i]);
                item3.SubItems.Add(String.Empty);
                listView1.Items.Add(item3);
            }
        }
    }
    private void addColumns()
    {
        listView1.Columns.Add("Column 1", -2, HorizontalAlignment.Left);
        listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
    }
