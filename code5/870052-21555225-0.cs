    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file))
    {
        connection.Open();
        OleDbCommand command = new OleDbCommand("CREATE TABLE trololol (id datetime NOT NULL PRIMARY KEY, blob longbinary)", connection);
        command.ExecuteNonQuery();
    }
