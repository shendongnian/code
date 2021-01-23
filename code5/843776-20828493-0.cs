    using (OleDbConnection conn = new OleDbConnection())
    {
        string pgp = pgpText.Text;
        string team = teamText.Text;
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='db.mdb'";
        OleDbCommand command = new OleDbCommand();
        command.Connection = conn;
        command.CommandText = "UPDATE PGP SET PGP=?,Team=? WHERE ID=?";
        command.Parameters.Add("pgp", OleDbType.VarChar).Value = pgp;
        command.Parameters.Add("team", OleDbType.VarChar).Value = team;
        command.Parameters.Add("id", OleDbType.VarChar).Value = pgp;
        conn.Open();
        int affectedRows = (int) command.ExecuteNonQuery();
        if (affectedRows == 0)
        {
            command.CommandText = "INSERT INTO PGP (PGP,Team) VALUES (?, ?)";
            // Remove the parameter for ID; the other two are fine
            command.Parameters.RemoveAt(2);
            command.ExecuteNonQuery();
        }
    }
