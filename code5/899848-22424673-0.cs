    static void Main(string[] args)
    {
        string connString = "Server=localhost;Port=3306;Database=connection;Uid=root;password=;";
        MySqlConnection conn = new MySqlConnection(connString);
        MySqlCommand command = conn.CreateCommand();
        command.CommandText = "Select number from user where id=@Id";
        command.Parameters.Add("@Id", SqlDbType.Int);
        command.Parameters["@Id"].Value = 1;
        try
        {
            conn.Open();
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader["number"].ToString());
        }
        Console.ReadLine();
    }
