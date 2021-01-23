    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand("select XmlColumn from Table", connection))
    {
    connection.Open();  
    using (SqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            var xmlDoc = XDocument.Load(reader["XmlColumn"].ToString());
            // do sth with xml:
            var id = xmlDoc.Elements().Where(e => e.Name.Equals("Ping")).Select(e => e.Attribute("id").Value);
        }
    }
    }
