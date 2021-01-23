    /// <summary>
    /// class which controlls the database, 
    /// </summary>
    public class DBConnect
    {
        private MySqlConnection connection;
    
        /// <summary>
        /// the constructor which starts to initialize the database.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public DBConnect(string username, string password)
        {
            Initialize(username, password);
        }
    
        /// <summary>
        /// initiates connection string for the database.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        private void Initialize(string username, string password)
        {
            string server = "Localhost";
    
            string database = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
    
            connection = new MySqlConnection(connectionString);
        }
    
        
        /// <summary>
        /// opens the connection to the database
        /// </summary>
        /// <returns></returns>
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can catch your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //1042: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 1042:
                        MessageBox.Show("MySqlException: cannot connect to the server");
                        break;
    
                    //case 1045:
                    //    MessageBox.Show("Invalid username/password, please try again");
                    //    break;
                }
                MessageBox.Show(ex.Message + "\r\n" +
                    ex.StackTrace);
                return false;
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe);
                MessageBox.Show("Er is al een connectie geopend");
                return false;
            }
        }
    
        /// <summary>
        /// closes the connection with the database
        /// </summary>
        /// <returns>true or false depending on the succes of closing the connection</returns>
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    
        /// <summary>
        /// generally used to get multpile rows of data from the datbase
        /// </summary>
        /// <param name="query">SQL statement</param>
        /// <returns></returns>
        public DataTable Select(MySqlCommand cmd)
        {
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                cmd.Connection = connection;
    
                //Read the data and store it in a DataTable
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                try
                {
                    da.Fill(dt);
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("An exception has occured loading the data: \n" + e.Message);
                    Console.WriteLine(e.Message);
                }
    
                //close Connection
                this.CloseConnection();
    
                //return list to be displayed
                return dt;
            }
            else
            {
                return null;
            }
        }
    }
