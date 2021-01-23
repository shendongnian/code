    public static DataTable GetRefDrList(string typeofDr, bool display){
      DataTable refDrListTable = new DataTable();
      refDrListTable.RowChanged += Format;
      //....
      da.Fill(refDrListTable);
      //....
    }
    bool suppressFormat;
    private void Format(object sender, DataRowChangedEventArgs e){  
      if(suppressFormat) return;     
      suppressFormat = true;
      e.Row["Address"] = e.Row["Address"].ToString().Replace("%","\r\n");       
      suppressFormat = false;
    }
