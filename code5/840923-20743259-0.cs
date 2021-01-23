    public string StringFromDatabase()
        {
            SqlConnection connection = null;
            try
            {
                var dataSet = new DataSet();
                connection = new SqlConnection("Your Connection String Goes Here");
                connection.Open();
                var command = new SqlCommand("Your Stored Procedure Name Goes Here", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var dataAdapter = new SqlDataAdapter { SelectCommand = command };
                dataAdapter.Fill(dataSet);
                return dataSet.Tables[0].Rows[0]["Item"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
