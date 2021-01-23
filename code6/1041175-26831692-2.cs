      List<ColumnInfo> columnsInfo = new List<ColumnInfo>();
      foreach (string s in Properties.Settings.Default.StringCollection)
      {
        columnsInfo.Add((ColumnInfo)s);
      }
