        private void StoreSessionVar(string sessionVar, string userID)
        {
            string iDate = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
            string connectionString = "your connection string to the db goes here";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO UserSessions (InsertionDate, SessionVar, UserID) VALUES (@IDate, @SessionVarToStore, @UID)", connection))
                {
                    command.Parameters.Add(new SqlParameter("UID", userID));
                    command.Parameters.Add(new SqlParameter("SessionVarToStore", sessionVar));
                    command.Parameters.Add(new SqlParameter("IDate", iDate));
                    SqlDataReader reader = command.ExecuteReader();
                }
            }
        }
