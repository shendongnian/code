    using (var con = new OleDbConnection())
    {
        con.ConnectionString = myConnectionString;
        con.Open();
    
        using (var com = new OleDbCommand())
        {
            int rec_id = 1;                         //
            string rec_name = "Bubba";              //
            int rec_salary = 2000000;               //
            string rec_team = "Springfield Atoms";  // test data
            int rec_fortyYardDash = 99;             //
            string rec_position = "linebacker";     //
            bool rec_offense = false;               //
    
            string sql =
                    "INSERT INTO receivers (" +
                            "receiver_id, " +
                            "receiver_name, " +
                            "salary, " +
                            "team, " +
                            "forty_yard_dash, " +
                            "[position], " +
                            "offense " +
                        ") VALUES (?,?,?,?,?,?,?)";
            com.Connection = con;
            com.CommandText = sql;
            com.Parameters.AddWithValue("?", rec_id);
            com.Parameters.AddWithValue("?", rec_name);
            com.Parameters.AddWithValue("?", rec_salary);
            com.Parameters.AddWithValue("?", rec_team);
            com.Parameters.AddWithValue("?", rec_fortyYardDash);
            com.Parameters.AddWithValue("?", rec_position);
            com.Parameters.AddWithValue("?", rec_offense);
            com.ExecuteNonQuery();
        }
        con.Close();
    }
