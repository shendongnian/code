    public List<List<object>> 
    GetNonContiguousRowValue(Excel.Worksheet ws, string noncontiguous_address)
    {
        var addresses = noncontiguous_address.Split(','); // e.g. "A1:D1,A4:D4"
        var row_data = new List<List<object>>();
        
        // Get the value of one row at a time:
        foreach (var addr in addresses)
        {
            object[,] arr = ws.get_Range(addr).Value;
            List<object> row = arr.Cast<object>)
                                  .Take(arr.GetLength(dimension:1))
                                  .ToList<object>();
            row_data.Add(row);
        }
        return row_data;
    }
