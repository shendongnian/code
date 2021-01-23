      for (int i = 0; i < model.Data.Columns.Count; i++)
      {
        int result;
        if (int.TryParse(data.Min(x => TryConvertInt32((x.ItemArray[i] is System.DBNull || x.ItemArray[i] == null ? int.MaxValue : x.ItemArray[i]))).ToString(), out result))
        {
          model.Minimum.Add(DataTableUtility.MinValue(result));
        }
      }
