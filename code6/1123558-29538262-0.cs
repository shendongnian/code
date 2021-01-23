            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.CommandTimeout = timeout;
                sqlCommand.CommandType = CommandType.Text;
                conn.Open();
                object result = sqlCommand.ExecuteScalar();
                return result;
            }
