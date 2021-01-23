    string script = string.Format(File.ReadAllText(Path.Combine(path, "Procedure_fn.sql")), "MyDBName");
    using (SqlConnection conn = new SqlConnection(txtConstring.Text))
    {
        Server server = new Server(new ServerConnection(conn));
        server.ConnectionContext.ExecuteNonQuery(script);
    }
