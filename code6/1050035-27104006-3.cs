    using(OleDbConnection vcon = new OleDbConnection(conString))
    using(OleDbCommand vcom = vcon.CreateCommand())
    {
        vcom.CommandText = "UPDATE DefTask_List SET [Action]=@Action WHERE [SNo]=@SNo";
        vcom.Parameters.Add("?", OracleDbType.VarChar).Value = comboBox1.Text;
        vcom.Parameters.Add("?", OracleDbType.Integer).Value = (int)row.Cells[0].Value;
        // I assume your column types are NVarchar2 and Int32
        vcon.Open();
        int k = vcom.ExecuteNonQuery();
    }
