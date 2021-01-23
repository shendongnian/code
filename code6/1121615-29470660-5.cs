    int itemsCount = lboItem.Items.Count;
    for (int i = 0; i < itemsCount; i++)
    {
        string item = string.Format("{0} | {1}", lboItem.Items[i], lboQty.Items[i]);
        totalSales.Add(item);
        file2.WriteLine(item);
    }
