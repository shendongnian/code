    foreach(DataTable dt in ds.Tables)
    {
       if(dt.Rows.Count > 0 && dt.Columns.Contains("Value") && dt.Columns["Value"].DataType == typeof(int))
       {
           int firstValue = dt.Rows[0].Field<int>("Value");
           if(dt.AsEnumerable().Skip(1).All(r => r.Field<int>("Value") == firstValue))
           {
               dt.Columns.Remove("Value");
           }
       }
    }
