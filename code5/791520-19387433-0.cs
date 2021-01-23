    var results = new StringBuilder();
    while (dbReader.Read())
    {
        results.Append(dbReader[0].ToString());
    }
    txtDatabaseResults.Text = results.ToString();
