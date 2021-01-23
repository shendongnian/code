    public DataTable Method()
    {
    foreach (DataRow dtRow in dtTable.Rows)
    {
     // On all tables' columns
     foreach(DataColumn dc in dtTable.Columns)
     {
     if(dtRow[dc].ToString()=="SomeValue")
      {
       dtRow[dc].ToString()="SetYourValue";
      }
     }
    }
    return dtTable;
    }
