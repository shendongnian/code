    private IDataReader Connection(string Command)
    {
        IDataReader dataReader = null;
 
        if (DBtype == "MySQL")
        {
            MySqlConnection MysqlConnection1 = new MySqlConnection(CS);
            MySqlCommand MySqlcommand = new MySqlCommand(Command, MysqlConnection1);
            MysqlConnection1.Open();
            dataReader = MySqlcommand.ExecuteReader();
        }
        else
        {
            SqlConnection sqlConnection1 = new SqlConnection(CS);
            SqlCommand Sqlcommand = new SqlCommand(Command, sqlConnection1);
            sqlConnection1.Open();
            dataReader = Sqlcommand.ExecuteReader();
        }  
        return dataReader;
    }
