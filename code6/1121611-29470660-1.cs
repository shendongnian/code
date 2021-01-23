    int itemsCount = lboItem.Items.Count;
    for (int i = 0; i < itemsCount; i++)
    {
        string item = lboItem.Items[i] + " | " + lboQty.Items[i];
        totalSales.Add(item);
        file2.WriteLine(item);
    }
