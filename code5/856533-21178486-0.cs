    private int MyTimeValue()
        {
            int Value = 0;
            string connectionString = GetConfigurationSettingValue("ConnectionString");
            int Days = 120;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select [dbo].[My_function] (@Span)", connection))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@Span", Days));
                    object o=cmd.ExecuteScalar();
                    if(o!=null)
                       Value = Convert.ToInt32(o);
                }
            }
            return (Value);
        }
