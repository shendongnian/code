    var items = new List<praktikanter>();
    string sql = @"SELECT p.*, f. Navn 
                   FROM praktikanter p INNER JOIN forlob f ON p.id = f.praktikantid
                   WHERE f.firmaid = @firmaid";
    using (var con = new MySqlConnection(connectionString))
    using (var command = new MySqlCommand(sql, con))
    {
        command.Parameters.Add(new MySqlParameter("@firmaid", MySqlDbType.VarChar).Value = firmaid);
        con.Open();
        using (var rd = command.ExecuteReader())
        {
            while (rd.Read())
            {
                string praktikant = rd.GetString("Navn");
                string fra = rd.GetString("Fra");
                string til = rd.GetString("Til");
                items.Add(new praktikanter(praktikant, fra, til));
            }
        }
    }
