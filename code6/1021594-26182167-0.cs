    public class LexicalOperations
    {
        public static List<string> WordLibrary()
        {
            List<string> WordLibrary = new List<string>();
            string conString = "Data Source=.;Initial Catalog=QABase;Integrated Security=True";
            string sqlIns = "select WordList from NewWords";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(sqlIns, connection))
            {
                connection.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        string noQuotes = reader.GetString(0).Replace("\"", "");
                        WordLibrary.Add(noQuotes);
                    }
                }
            }
            return WordLibrary;
        }
    }
