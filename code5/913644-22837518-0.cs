    if (!IsPostBack)
    {
        string server = "wisteria.arvixe.com";
        string database = "greenhouse";
        string uid = "******";
        string password = "******";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string cmd = "SELECT COUNT(*) FROM registration WHERE Username='" + TextBoxUN.Text + "'";
            MySqlCommand userExist = new  MySqlCommand(cmd, connection);
            object obj = userExist.ExecuteScalar();
            
            int temp = -1;
  
            if (obj != DBNull.Value)
            {
               temp = Convert.ToInt32(obj);  
            }             
               
            if (temp == 1)
            {
                Response.Write("User already exist..!!!");
            }
            connection.Close();
    }
