    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rawr"].ConnectionString);
                SqlCommand cmdselect = new SqlCommand();
                cmdselect.CommandType = CommandType.StoredProcedure;
                cmdselect.CommandText = "[dbo].[prcLoginv]";
                cmdselect.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = Username;
                cmdselect.Parameters.Add("@UPassword", SqlDbType.VarChar, 50).Value = Password;
                cmdselect.Parameters.Add("@OutRes", SqlDbType.Int, 4);
                cmdselect.Parameters["@OutRes"].Direction = ParameterDirection.Output;
                cmdselect.Connection = con;
                int Results = 0;
    
                try
                {
                    con.Open();
                    cmdselect.ExecuteNonQuery();
                    Results = (int)cmdselect.Parameters["@OutRes"].Value;
                }
                catch (SqlException ex)
                {
                    lblMessage.Text = ex.Message;
                }
                finally
                {
                    cmdselect.Dispose();
    
                    if (con != null)
                    {
                        con.Close();
                    }
                }
                return Results;
            }
