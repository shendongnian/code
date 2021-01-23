    DataRow dr = dt.NewRow();
    
    
    
    bool alreadyExist = false;
    for (int x = 0; x < dt.Rows.Count; x++) {
      var rowInDb = string.Join("|", dt.Rows[x].ItemArray.Select(p => p.ToString()).ToArray());
      var newRow = string.Join("|", dr.ItemArray.Select(p => p.ToString()).ToArray());
    
      if (rowInDb.Equals(newRow)) {
        alreadyExist = true;
      }
    }
        
    if (alreadyExist == false) {
      // Do something you want to do
    }
