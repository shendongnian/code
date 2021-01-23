    StringBuilder e = new StringBuilder();
    while (dbReader.Read())
    {
       e.Append(dbReader[0].ToString());
    }
    txtDatabaseResults.Text = e.ToString();
