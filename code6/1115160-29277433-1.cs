    public int CheckFileExists(string fileName)
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultCSRConnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbl_reports WHERE report_file=@report_file", con);
                cmd.Parameters.Add("@report_file", SqlDbType.VarChar).Value = fileName;
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }
