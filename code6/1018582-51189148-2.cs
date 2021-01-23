    // fill dt with information
    DataTable dt = new DataTable();
    
    // create a new row and fill it with information
    DataRow dr = dt.NewRow();
    
    // distinct
    bool isDistinct = true;
    for (int i=0; i < dt.Rows.Count; i++)
    {
      // check if both rows are equal
      if (Enumerable.SequenceEqual(dt.Rows[i].ItemArray, dr.ItemArray))
      {
        // it already exists
        isDistinct = false;
        break;
      }
    }
        
    if (isDistinct)
    {
      dt.Rows.Add(dr);
    }
