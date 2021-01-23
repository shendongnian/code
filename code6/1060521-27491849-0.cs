    for (int x = 0; x < arrayList.Count; x++)
    {
        //if x is 0 it's the first iteration so we want "IF"; otherwise we want ""
        ListViewItem item = new ListViewItem(x == 0 ? "IF" : "");
        //add the rest of the empty sub-elements with a loop
        for (int y = 1; y < x; y++)
        {
            item.SubItems.Add("");
        }
        item.SubItems.Add("ID");
        item.SubItems.Add("EX");
        item.SubItems.Add("MEM");
        item.SubItems.Add("WB");
        for (int k = 5; k < ccNum; k++)//Set rest of row cells ""
            item.SubItems.Add("");
        listView5.Items.Add(item);
    }
