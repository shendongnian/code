    public static class Extensions
    {
        public static int Count(this MySqlDataReader dr)
        {
            int count = 0; 
            while(dr.Read())
                count++;
            return count;
        }
    }
