    class Sqlconnection
    {
        private SqlConnection connection;
        public bool MakeConnection() 
        {
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionInfo"].ConnectionString);
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
        public void connectionClose()
        {
            connection.Close();
        }
        ....
    }
