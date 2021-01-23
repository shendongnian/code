    public void CheckDuplicateRows(DataTable dTable, string colName)
    {
       Hashtable hTable = new Hashtable();
       ArrayList duplicateList = new ArrayList();
    
       //Add list of all the unique item value to hashtable, which stores combination of     key, value pair.
       //And add duplicate item value in arraylist.
       foreach (DataRow drow in dTable.Rows)
       {
          if (hTable.Contains(drow[colName]))
             duplicateList.Add(drow);
          else
             hTable.Add(drow[colName], string.Empty); 
       }
      //Checks the list dimension to verify if there is any duplicate
      if(duplicateList.Count() > 0)
      {
      //you can print your message here or eventually get info about the duplicate row
      }   
    }
