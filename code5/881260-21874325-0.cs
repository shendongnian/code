        public DataTable getDataTable()
        {
            using (SqlConnection sqlCon = new SqlConnection("connectionString"))
            using (SqlCommand cmd = new SqlCommand("sp_getData", sqlCon))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlCon.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            }
        }
