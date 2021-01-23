       public static DataSet selectStudent()
        {
            MySqlConnection conn = connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            MySqlDataAdapter adap = new MySqlDataAdapter(@"SELECT * FROM person", conn);
            MySqlCommandBuilder sqlCmd = new MySqlCommandBuilder(adap);
            DataSet sqlSet = new DataSet();
            adap.Fill(sqlSet, "personID");
            conn.Close();
            return sqlSet;
        }
