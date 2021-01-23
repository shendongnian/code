     public DataSet SelectTopic(LessionPlanBEL bellp)
                {
                    SqlDataReader dr = new SqlDataReader();
                    SqlCommand cmd;
                    try
                    {
                        con.Open();
                        cmd =new SqlCommand( "Select * from lessiontopic where subject=@subject ",conn);
                       
                        cmd.Parameters.AddWithValue("@subject", bellp.subject.ToString());
         dr=cmd.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
        
                    }
                    finally
                    {
                        con.Close();
                    }
        
                }
