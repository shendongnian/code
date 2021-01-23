    List<string> list = new List<string>();
    for (int i = 0; i < ServerGroupIds.Rows.Count; i++)
    {
        string rowAsString = string.Join(", ", ServerGroupIds.Rows[i].ItemArray);
        list .Add(rowAsString );
    }
    string[] array = list.ToArray();
