        public List<IRegistration> SearchRegistrations(string firstname, string email, string phone, string studentid)
        {
            List<IRegistration> result = new List<IRegistration>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString);
            using (conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SEARCH_REGITRATION]", conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Registration reg = new Registration();
                    // Do property mappings here
                    result.Add(ci);
                }
                rd.Close();
            }
            return result;
        }
