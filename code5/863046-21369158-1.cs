    for(int i = 0; i < rows.Length; i++)
    {
        String str = rows[i];
        String[] items = str.Split(new char[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
        if (items.Length == 2)
        {
            dataGrid_FileContents.Rows.Add(items[0], items[1]);
        }
    }
