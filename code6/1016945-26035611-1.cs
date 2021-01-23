    string text = "Table 'ProductCostHistory'. Count 1, logical 5, physical 0";
    int index = text.IndexOf("Table '");
    if(index >= 0)  // no Contains-check needed
    {
        index += "Table '".Length; // we want to look behind it
        int endIndex = text.IndexOf("'.", index);
        if(endIndex >= 0)
        {
            string tableName = text.Substring(index, endIndex - index);
            Console.Write(tableName); // ProductCostHistory
        }
    }
