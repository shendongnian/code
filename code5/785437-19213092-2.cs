    public static DataTable GetRefDrList(string typeofDr, bool display){
      DataTable refDrListTable = new DataTable();
      refDrListTable.ColumnChanged += Format;
      //....
      da.Fill(refDrListTable);
      //....
    }
    private void Format(object sender, DataColumnChangedEventArgs e){
       if(e.Column.ColumnName == "Address"){
          e.PopposedValue = e.ProposedValue.ToString().Replace("%","\r\n");
       }
    }
