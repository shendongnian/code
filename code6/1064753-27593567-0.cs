    using MySql.Data.MySqlClient;
    
  
        private void btnStoreCon_Click(object sender, EventArgs e)
        {
            MySqlConnection connection;
            string server;
            string database;
            string uid;
            string password;
    
            server = txtServer.Text;
            database = txtDatabase.Text;
            uid =  txtUsername.Text;
            password =txtPassword.Text;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
    		database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
    
            connection = new MySqlConnection(connectionString);
        }
