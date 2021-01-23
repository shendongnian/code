        public static bool CheckConnection()
        {
            try
            {
                MyContext.Database.Connection.Open();
                MyContext.Database.Connection.Close();
            }
            catch(SqlException)
            {
                return false;
            }
            return true;
        }
