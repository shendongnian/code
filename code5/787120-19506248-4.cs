    public class AtsRawQuery
    {
        private string ConnetionString = "";
        
        public AtsRawQuery(string connectionString)
        {
            this.ConnetionString = connectionString;
        }
    
        public List<List<string>> Query(string queryString)
        {
            List<List<string>> results = null;
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
    
            try
            {
                conn = new MySqlConnection(this.ConnetionString);
                conn.Open();
    
                MySqlCommand cmd = new MySqlCommand(queryString, conn);
                rdr = cmd.ExecuteReader();
    
                if (rdr.HasRows)
                {
                    results = new List<List<string>>();
                    while (rdr.Read())
                    {
                        List<string> curr_result = new List<string>();
                        for (int columnIndex = 0; columnIndex <= rdr.FieldCount - 1; columnIndex++)
                        {
                            curr_result.Add(rdr.GetString(columnIndex));
                        }
                        results.Add(curr_result);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
    
                if (conn != null)
                {
                    conn.Close();
                }
    
            }
            return results;
        }
    }
