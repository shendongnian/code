    string script = File.ReadAllText(Path.Combine(path, "Procedure_fn.sql"));
    using (SqlConnection conn = new SqlConnection(txtConstring.Text))
    using (SqlCommand cmd = new SqlCommand(script, conn))
    {
        cmd.Parameters.Add("@DBName", SqlDbType.NVarChar, 50).Value = "MyDatabaseName";
        conn.Open();
        cmd.ExecuteNonQuery(script);
    }
