    private void compareDataTables()
    {
      // I assume that datatables are of same length
      for(int i = 0; i < excelDataTable.Rows.Count; i++)
      {
        // Assuming that given columns in both datatables are of same type
        if(excelDataTable.Rows[i]["col_name"] == sqlDataTable.Rows[i]["col_name"])
        {
          //your code
        }
    }
