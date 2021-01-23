        public static bool CheckConnection()
        {
            try
            {
                MyContext.Database.Connection.Open();
            }
            catch(SqlException)
            {
                return false;
            }
            return true;
        }
