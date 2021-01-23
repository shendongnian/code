    public static class Procedures
    {
        public static void RegisterUser() // add whatever parameters you need
        {
            using (var cn = new SqlConnection(yourConnectionString))
            using (var cmd = new SqlCommand(yourQuery, cn))
            {
                // do stuff
            }
        }
    }
