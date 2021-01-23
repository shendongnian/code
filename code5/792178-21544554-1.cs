        Try This     
        
    List<string> selectedAddress = new List<string>();
    protected DataView GetSelectedItems()
    {
    DataView dvResult = new DataView(dtresult);
    string query = "";
    int count = selectedAddress.Count();
               
                   for (int j = 0; j < selectedAddress.Count; j++)
                   {
                       string val = selectedAddress[j].ToString() + ",";
                       query += val;
                   }
                   query = query.Remove(query.Length - 1);
               dvResult.RowFilter = "ID IN(" + query + ")";
               return dvResult;
    }
