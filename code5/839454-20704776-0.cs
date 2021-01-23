    // ...
    foreach (DataColumn dc in DgvChangedDT.Columns)
    {
      string nameOfColumn = dc.ColumnName; // <----
      OrgVal = dr[dc, DataRowVersion.Original].ToString();
      CurrVal = dr[dc, DataRowVersion.Current].ToString();
      MessageBox.Show("Original Value: " + OrgVal + " ," + " Current Value: " +           CurrVal);
    }
    // ...
