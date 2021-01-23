    using (SqlDataReader reader = CallStoredProcedure())
    {
       return reader.Cast<System.Data.Common.DbDataRecord>().Select(rec => new ABC()
       {
          A = (int)rec[0],
          B = rec.GetString(1),
          C = (int)rec[2],
          DEFObj = // iterate over rec[3]? Don't know what your data looks like at this point...
       }).toList();
    }
