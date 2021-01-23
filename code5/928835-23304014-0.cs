    foreach (var row in try2)
    {
        Debug.Print(row.Type1.ToString());
        foreach(var item in row.Type2)
        {
            Debug.Print(item.GA_ITEM);
            Debug.Print(item.REM_QTY);
        }
    }
