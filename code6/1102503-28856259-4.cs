    public static bool Conflicting(this DataTable dt, params Tuple<string, object>[] columnWithValue)
    {
        return dt.AsEnumerable().Any(row =>
        {
              for (int i = 0; i < columnWithValue.Length; i++)
              {
                    // check for null values
                    if (row.IsNull(columnWithValue[i].Item1))
                    {
                        if (columnWithValue[i].Item2 != null) 
                           return false;
                    }
                    else
                    {
                       if (!row[columnWithValue[i].Item1].Equals(columnWithValue[i].Item2)) 
                           return false;
                    }
               }
               return true;
          });
    }
