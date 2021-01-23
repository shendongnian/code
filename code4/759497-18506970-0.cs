            {
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
                else
                {
                    SqlConnection.Open();
                }
                return SqlConnection;
            }`
