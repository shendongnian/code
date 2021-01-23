    string[] arr = new string[datareader.FieldCount];
    ListViewItem itmx;
    while (datareader.Read())
    {
        for(int i=0;i<datareader.FieldCount;i++)
        {
            arr[i]=datareader.GetValue(i).ToString();
        }
        itmx = new ListViewItem();
        listView1.Items.Add(itmx);
    }
