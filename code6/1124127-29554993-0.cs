    using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplicationtodatabase.Properties.Settings.DatabasewebConnectionString"].ConnectionString));
    {
    SqlCommand cmd = new SqlCommand("INSERT INTO webtable (Id, url_name) VALUES (@id, @url)",conn);
    cmd.Parameters.AddWithValue("@url", "nagia");
    cmd.Parameters.AddWithValue("@id", "9");
    cmd.Connection = conn;
    cmd.Open();
    cmd.ExecuteNonQuery();
    cmd.Close();
    }
