    public class X
    {
        public void PerformQuery(...)
        {
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                // create parameters and parameter values
                cmd.ExecuteNonQuery();
            }
        }
    }
