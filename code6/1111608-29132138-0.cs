    MySqlConnection conn;
    MySqlCommand comm;
    MySqlDataReader read;
    string
    server = "50.60.170.180",
    database = "this_is_my_database_name",
    dbPassword = "this_is_my_password",
    dbUserName = "this_is_my_user_name";
    string ConnectionString
    {
        get
        {
            return "SERVER=" + server + ";DATABASE=" + database + ";UID=" + dbUserName + ";PASSWORD=" + dbPassword;
        }
    }
    void InitDB()
    {
         conn = new MySqlConnection(ConnectionString);
         conn.Open();
         comm = new MySqlCommand();
         comm.Connection = conn;
    }
    void ReadEntry() 
    {
         comm.CommandText = "Select * From MyTable";
         read = comm.ExecuteReader();
         while (read.Read()) 
         {
             string i_got_something_from_the_web = read[0].ToString();
         }
         read.Close();
    }
 
