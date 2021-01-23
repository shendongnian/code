     int i = 0;
     ListViewItem item = new ListViewItem();
     foreach (string strValue in strArray)
     {
        i++;
        if (i == 1)
        {
           item = new ListViewItem();
           item.Text = strValue;
        }
        if (i == 2)
        {
            item.SubItems.Add(strValue);
            listView1.Items.Add(item);
            i = 0;
        }
     }
