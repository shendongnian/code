    foreach(DataTable dt in ds.Tables){
      foreach(DataRow row in dt.Rows){
         for(int i = 0; i < dt.Columns.Count; i++){
           if(object.Equals(row[i],"01/01/1754 00:00:00")) row[i] = null;
         }
      }
    }
