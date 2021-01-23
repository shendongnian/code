       //1 Execute query against SP Linq provider   
        string keyCol = "SPFieldName";
        CamlQuery keyColumnValuesQuery = CamlQuery.CreateAllItemsQuery();
        ListItemCollection keyColumnValues = srcDocLib.GetItems(keyColumnValuesQuery);
        spContext.Load(keyColumnValues, items => items.Include(item => item[keyCol]), items => items.OrderBy(item => item[keyCol]));
        spContext.ExecuteQuery();
        //2. Transform LiItemCollection to a List and perform Distinct operation 
        var uniqueKeyColumnValues = keyColumnValues.ToList().Select(i => i[keyCol]).Distinct(); 
    
