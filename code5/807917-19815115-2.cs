    //Creation of the DestinationTable datatable
    var DestinationTable = new DataTable("Destination");
    DestinationTable.Columns.Add("Invoice", typeof(String)); //Correct Type?
    DestinationTable.Columns.Add("Date", typeof(String));
    DestinationTable.Columns.Add("User", typeof(String));
    DestinationTable.Columns.Add("LineNo", typeof(String));
    DestinationTable.Columns.Add("Article", typeof(String));
    DestinationTable.Columns.Add("Qty", typeof(String));
    for(int i = 0; i < AmountOfNewLines - 1; i++)
    {
      //Create a new row
      //Invoice|Date    |User |LineNo|Article|Qty
      foreach(DataRow d in SourceDataTable)
      {
        //Using the foreach makes the datarow more easier to approach
        //The Number inside the brackets explains which column is being approached.
        DestinationTable.Rows.Add(d[0], d[1], d[2], d[3+(3*i)], d[4+(3*i)], d[5+(3*i)])
      }
      
    }
