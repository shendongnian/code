    public static DataSet XElementToDataSet(XElement xeRecordsList)
    {
      DataTable dtRecordsList = new DataTable();
      XElement setup = (from p in xeRecordsList.Descendants() select p).First();
      // builds DataTable
     foreach (XElement xe in setup.Descendants())
     dtRecordsList.Columns.Add(new DataColumn(xe.Name.ToString(), typeof(string)));
     // add columns to your dt
    var all = from p in xeRecordsList.Descendants(setup.Name.ToString()) select p;
    foreach (XElement xe in all)
    {
     DataRow dr = dtRecordsList.NewRow();
     //adding the values
     foreach (XElement xe2 in xe.Descendants())
     {
       bool boolColExists = false;
       //Check for column exists in datatable
       foreach (DataColumn col in dtRecordsList.Columns) 
       {
          if (col.ColumnName == xe2.Name.ToString())
          {
            boolColExists = true;
            break;
          }
       }
      if (boolColExists)
      dr[xe2.Name.ToString()] = xe2.Value;
     }
     dtRecordsList.Rows.Add(dr);
    }
    DataSet dstRecordsList = new DataSet("RECORDLIST");
    dstRecordsList.Tables.Add(dtRecordsList);
    dstRecordsList.Tables[0].TableName = "RECORD";
    return dstRecordsList;
    }
