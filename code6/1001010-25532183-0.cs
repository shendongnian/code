    for (int i = 0; i < datatable.Rows.Count; i++)
    {
        IDictionary<string, object> nextItem = new ExpandoObject();
        for (int v = 0; v < datatable.Columns.Count; v++)
        {
            nextItem[datatable.Columns[v].ColumnName] = 
                datatable.Rows[i].ItemArray[v];
        }
        products.Add(nextItem);
    }
