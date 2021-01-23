     try
        {  
           DataTable Tbl = new DataTable();
            OleDbConnection conn = new OleDbConnection(GetConnectionStringAccess());
            string cSQL = "SELECT Cracha, Data_Hora, Terminal, Entrada_Saida, Situacao, Tipo, Divergencia, SaiuMarcacao, Justificativa, IDMarcacao, PIS, NSR FROM Marcacao";
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = cSQL;
            cmd.CommandType = CommandType.Text;
            OleDbDataReader dr = cmd.ExecuteReader();
            Tbl.Load(rd,LoadOption.OverwriteChanges);
            conn.Close();
            return Tbl;
        }
        catch (Exception ex)
        {
            throw;
        }
    
   
    
