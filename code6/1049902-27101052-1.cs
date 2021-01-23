    internal List<employee> loadLST()
    {
        string query = "select name, grade from emp";
        // we should dispose IDisposable implementations:
        // connection, command and data reader
        using (var con = new MySqlConnection(ConnectionString))
        {
            con.Open();
            using (var cmd = new MySqlCommand(query, con))
            using (var rdr = cmd.ExecuteReader())
            {
                // it is hard to maintain manual mapping
                // between query results and objects;
                // let's use helper like Automapper to make this easier
                Mapper.CreateMap<IDataReader, employee>();
                Mapper.AssertConfigurationIsValid();
                return Mapper.Map<List<employee>>(rdr);
            }
        }
    }
