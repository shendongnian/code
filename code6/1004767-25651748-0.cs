    using System;
    //etc etc
    using MySql.Data.MySqlClient;
    //etc etc
     
    namespace myapp
    {
        class Myclass
        {
            static void Mymethod(string[] args)
            {
                string connStr = "server=server;user=user;database=db;password=*****;";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
     
                string sql = "SELECT this FROM that";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader()) {
                    while (rdr.Read()) {
                        /* iterate once per row */
                    }
                }
            }
        }
    }
