     public int CreateNewMember(string Mem_NA, string Mem_Occ )
            {
                using (SqlConnection con=new SqlConnection(Config.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Mem_Basic(Mem_Na,Mem_Occ) output INSERTED.Id VALUES(@na,@occ)", con))
                    {
                        cmd.Parameters.AddWithValue("@na", Mem_NA);
                        cmd.Parameters.AddWithValue("@occ", Mem_Occ);
                        con.Open();
                        int modified = (int)cmd.ExecuteScalar();
                        using (SqlCommand cmd1 = new SqlCommand("INSERT INTO Mem_Details (Mem_Id,Mem_Role) VALUES (@id,@role)", con))
                        {
                            cmd1.Parameters.AddWithValue("@id", modified);
                            cmd1.Parameters.AddWithValue("@role","Member");
                            cmd1.ExecuteNonQuery();
                        }
                        if (con.State == System.Data.ConnectionState.Open) con.Close();
                        return modified;
                    }
                }
            }
