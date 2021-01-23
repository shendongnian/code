    public int getCount(int usercode){
      int count = 0;
      DataTable mytable = getAllRowsAndReturnAsDataTable(); // assigning a DataTable value to mytable. 
      if (mytable.Rows.Count > 0) { 
        count = mytable.AsEnumerable().Count();  // No WHERE function call so no casting.
      } 
      return count;
    }
