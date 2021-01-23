        /// <summary>
        /// Execute a SQL Query statement, using the default SQL connection for the application
        /// </summary>
        /// <param name="query">SQL query to execute</param>
        /// <returns>DataTable of results</returns>
        public static DataTable Query(string query)
        {
            DataTable results = new DataTable();
            string configConnectionString = "ApplicationServices";
            System.Configuration.Configuration WebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/Web.config");
            System.Configuration.ConnectionStringSettings connString;
            if (WebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = WebConfig.ConnectionStrings.ConnectionStrings[configConnectionString];
                if (connString != null)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connString.ToString()))
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                            dataAdapter.Fill(results);
                        return results;
                    }
                    catch (Exception ex)
                    {
                        throw new SqlException(string.Format("SqlException occurred during query execution: ", ex));
                    }
                }
                else
                {
                    throw new SqlException(string.Format("Connection string for " + configConnectionString + "is null."));
                }
            }
            else
            {
                throw new SqlException(string.Format("No connection strings found in Web.config file."));
            }
        }
