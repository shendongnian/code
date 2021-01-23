    DataSet da= new DataSet();
    DataTable theTable = new DataTable();
    da.Tables.Add(theTable);
         this.klantengegevensTableAdapter.Fill(da.Tables[0]);
         tbVoornaam.text = da.Tables[0].Rows[0]["Voornaam"].ToString(); 
