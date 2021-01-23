    if (clb.CheckedItems.Count != 0)
    {
        StringBuilder sb = new StringBuilder();
        foreach(string item in clb.CheckedItems)
            sb.AppendLine(item);
        display = "Items needed\n-----------\n\n\n" + sb.ToString();
    }
