    int itemsCount = Math.Min(lboItem.Items.Count, lboQty.Items.Count);
    for (int i = 0; i < itemsCount; i++)
    {
        string item = "";
        if (i < lboItem.Items.Count)
            item = lboItem.Items[i].ToString();
        item += " | ";
        if (i < lboQty.Items.Count)
            item += lboQty.Items[i].ToString();
        totalSales.Add(item);
        file2.WriteLine(item);
    }
