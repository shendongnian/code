    private class PKExclusiveComparer<T> : IEqualityComparer<T> where T : DataRow
    {
      public bool Equals(T x, T y)
      {
        bool result = true;
        foreach (DataColumn col in (x as DataRow).Table.Columns)
        {
          if (!(x as DataRow).Table.PrimaryKey.Contains(col))
          {
            result &= x[col].Equals(y[col]);
          }
        }
        return result;
      }
      public int GetHashCode(T x)
      {
        string code = string.Empty;
        foreach (DataColumn col in (x as DataRow).Table.Columns)
        {
          if (!(x as DataRow).Table.PrimaryKey.Contains(col))
          {
            code += x[col].ToString();
          }
        }
        return code.GetHashCode();
      }
    }
