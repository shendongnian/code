    string val = null;
    foreach (DataTable dt in ds.Tables)
    {
        foreach (DataRow dr in dt.Rows)
        {
            foreach (DataColumn dc in dt.Columns)
            {
                if(dc.ColumnName=="Name")
                  {
                        //save
                  }
            }
        }
    }
