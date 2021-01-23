    byte[] item1 = null;
    if (ds.Tables.Count > 0)
    {
       var table = ds.Tables[0];
       if (table.Rows.Count > 0)
       { 
          var row = table.Rows[0];
          if (row.Columns.Contains("FileImage")) 
          {
             item1 = (byte[])item["FileImage"];
          }
       }
    }
    if (item1 == null) 
    {
        //handle error
    }
