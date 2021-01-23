`
query = "UPDATE dbo.History SET Volume = @Volume WHERE Symbol = @Symbol AND [start] = @Date; ";
using (SqlConnection con = new SqlConnection(builder.ConnectionString))
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
cmd.Parameters.Add("@Symbol", SqlDbType.NVarChar, 50).Value = ti.Symbol;
                                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = ti.Date;
                                cmd.Parameters.Add("@Volume ", SqlDbType.Float).Value = ti?.Volume;
try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (System.InvalidCastException e)
                        {
                            throw;
                        }
                        
                        con.Close();
}
`
Nothing is saved to the database and the only way to get the message is through the "non public members" of the cmd.ExecuteNonQuery() method. When I check the parameters values there are all there and correct. 
