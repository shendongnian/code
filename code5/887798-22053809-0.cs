    try
    {
        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source= Z:\Tempesta\Area Progetto\Area_Progetto_20_02_2014\Area_Progetto_DATA_MAGAZINE\Data_Magazine\Data_Magazine\DB\DataMG.mdb";
    
        using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connectionString))
        {
        	string insertQuery = "INSERT into Prodotti ([Codice],[Descrizione],[Marchio],[Deposito],[Note],[NumeroProdotti],[PrzListinoBase_Aq],[PrzListinoBase_Ve],[Categoria],[Posizione],[Disponibilita],[QtaVenduta],[QtaAcquistata]) VALUES ('" + this.Codice.Text + "','" + this.Descr.Text + "','" + this.Marchio.Text + "','" + this.Deposito.Text + "'," + this.Note.Text + "," + this.NumProd.Text + "," + this.PrzListAcq.Text + "," + this.PrzListVen.Text + ",'" + this.Categ.Text + "','" + this.Posiz.Text + "'," + this.Disp.Text + "," + this.QtaVen.Text + "," + this.QtaAcq.Text + ")";
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(insertQuery, conn);
        	cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
        	conn.Close(); 
    	}
    }
