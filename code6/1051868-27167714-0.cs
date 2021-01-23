    // create intermediate dictionary to group the records
    Dictionary<string, DataRow> SummarizedRecords = new Dictionary<string, DataRow>();
    
    // iterate over all records 
    foreach(DataRow dRow in table.Rows)
    {
      // if the record is in the dictionary already -> sum the "n" value
      if(SummarizedRecords.ContainsKey(dRow["name"]))
      {
        SummarizedRecords[dRow["name"]].n += dRow["n"];
      }
      else
      {
        // otherwise just add the element
        SummarizedRecords[dRow["name"]] = dRow;
      }
    }
    
    // transform the dictionary back into a list for further usage
    ArrayList<DataRow> summarizedList = SummarizedRecords.Values.ToList();
