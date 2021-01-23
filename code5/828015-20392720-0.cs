            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnstring"].ConnectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL_COURSE_COMPONENTS; // Constant to my SQL statement containing a parameter @CourseId
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@CourseId";
                param.Value = CourseId;
                cmd.Parameters.Add(param);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    int CODE_ORDINAL = rdr.GetOrdinal("Code");
                    while (rdr.Read())
                    {
                        string code = rdr.IsDBNull(CODE_ORDINAL) ? (string)null : rdr.GetString(CODE_ORDINAL);
                        // .... Rest of the code here
                    }
                }
            }
