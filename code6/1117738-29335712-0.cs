    static void Main(string[] args)
    {
        MySQLFacade facade = new MySQLFacade("127.0.0.1", "omitted", "omitted", "imdb");
        MySqlDataReader reader = facade.Retrieve(
            @"SELECT title.id,title.title,title.production_year,movie_info.info
            FROM title
            NATURAL JOIN movie_info
            WHERE title.id <= 1000");
        using (reader)
        {
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(reader.GetValue(i));
                }
                Console.WriteLine();
            }
        }
        Console.ReadLine();
    }
