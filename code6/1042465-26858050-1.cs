    public Stream SelectEmployeeImageByID(int theID)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
            string sql = "SelectEmployeeImage";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", theID);
            connection.Open();
            object theImg = cmd.ExecuteScalar();
            try
            {
                return new MemoryStream((byte[])theImg);
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
