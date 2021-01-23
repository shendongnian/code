    public void PopulateCombo(ComboBox combo, 
        string tableName, string keyColumn, string valueColumn)
    {
    	dbh.openCon();
    
        try
        {
          var com = new SqlCommand(string.Format("SELECT {0}, {1} FROM {2}", keyColumn, valueColumn, tableName) , dbh.getCon());
          var reader = com.ExecuteReader();
          var dt = new DataTable();
    
          dt.Columns.Add(keyColumn, typeof(string));
          dt.Columns.Add(valueColumn, typeof(string));
          dt.Load(reader);
    
    	  combo.ValueMember = keyColumn;
    	  combo.DisplayMember = valueColumn;
    	  combo.DataSource = dt;
        }
        finally
        {
          dbh.closeCon();
        }
    }
    		
    PopulateCombo(cb_Choices, "BACKUPCONTRACTS", "ID", "ContractNumber");
    PopulateCombo(cb_Other, "Other", "OtherID", "OtherValue");
