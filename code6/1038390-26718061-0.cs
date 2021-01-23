            // Code in BO logic method
            string email = "ادمین";
            string password = "ادمین";
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Register WHERE Email=@Email AND Deleted=0 AND Password=@Pass");
            cmd.Parameters.AddWithValue(@"Email", email.Trim());
            cmd.Parameters.AddWithValue(@"Pass", password.Trim());
            DataSet dst = Varmebaronen.AppCode.DA.SqlManager.GetDataSet(cmd);
        //DataAccess Methods !
        public static DataSet GetDataSet(SqlCommand cmd)
        {
            return GetDataSet(cmd, "Table");
        }
        public static DataSet GetDataSet(SqlCommand cmd, string defaultTable)
        {
            SqlConnection conn = GetSqlConnection(cmd);
            try
            {
                DataSet resultDst = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(resultDst, defaultTable);
                }
                return resultDst;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
