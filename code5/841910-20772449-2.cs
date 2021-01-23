    public static class HelperFunctions
    {
        private static string connString = "your connection string";
        public static IEnumerable<User> GetAllUsers()
        {
            using (var conn = new SqlConnection(connString))
            using (var cmd = new SqlCommand(connection:conn))
            {
                // set your command text, execute your command 
                // get results and return
            }
        }
