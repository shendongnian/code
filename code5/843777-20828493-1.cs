    using (OleDbConnection conn = new OleDbConnection())
    {
        string pgp = pgpText.Text;
        string team = teamText.Text;
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='db.mdb'";
        OleDbCommand command = new OleDbCommand();
        command.Connection = conn;
        command.CommandText = "UPDATE PGP SET Team=? WHERE PGP=?";
        command.Parameters.Add("team", OleDbType.VarChar).Value = team;
        command.Parameters.Add("pgp", OleDbType.VarChar).Value = pgp;
        conn.Open();
        int affectedRows = (int) command.ExecuteNonQuery();
        if (affectedRows == 0)
        {
            command.CommandText = "INSERT INTO PGP (Team, PGP) VALUES (?, ?)";
            // Parameters as before
            command.ExecuteNonQuery();
        }
    }
