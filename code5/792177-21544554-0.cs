    Try This     
    
    List<string> selectedAddress = new List<string>();
        DataTable dtFinal = new DataTable();
        DataView dvResult = new DataView(dtAddress);
        string query = "";
                   for (int j = 0; j < selectedAddress.Count; j++)
                   {
                       string val = selectedAddress[j].ToString() + ",";
                       query += val;
        
                   }
        
                   query = query.Remove(query.Length - 1);
                   dvResult.RowFilter = "ID IN(" + query + ")";
        dtFinal = dvResult.ToTable();
