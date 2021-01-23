     static void Main(string[] args)
        {
            using (MySqlConnection conn = new MySqlConnection("server=::1;uid=ipv6test;pwd=root;database=test1;CharSet=utf8"))
            {
                string sql = "select * from host";
                using (MySqlCommand comm = new MySqlCommand(sql, conn))
                {
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        string host = reader["host"] == System.DBNull.Value ? string.Empty : reader["host"].ToString();
                        Console.WriteLine(host);
                    }
                    reader.Close();
                }
            }
            Console.ReadKey();
        }
