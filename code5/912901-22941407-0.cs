        /// <summary>
        /// Accepts a SQL Connection string, and censors it by *ing out the password.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static string CensorConnectionString(string connectionString)
        {
            var builder = new DbConnectionStringBuilder() {ConnectionString = connectionString};
            if (builder.ContainsKey("password"))
            {
                builder["password"] = "*****";
            }
            return builder.ToString();
        }
