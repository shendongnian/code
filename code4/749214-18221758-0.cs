    public class SqlClass
    {
        public void ExecuteNonQuery(string sqlStatement, Dictionary<string, object> parameters)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
        
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sqlStatement;
        
                    foreach(var keyValuePair in parameters)
                    {
                        command.Parameters.Add(new SqlParameter(keyValuePair.Key, keyValuePair.Value));
                    }
        
                    command.ExecuteNonQuery();
                   
                }
            }
        }
    }
