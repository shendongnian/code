    public IEnumerable<fgrTemplate> StuVerifications(int ID)
                {
                    cn.Open();
                    SqlCommand com = new SqlCommand("SELECT Template FROM tblFingerprint WHERE ID = '" + ID + "'", cn);
                    //com.Parameters.AddWithValue("ID", i);
                    SqlDataReader sd = com.ExecuteReader();
                    while (sd.Read())
                    {
                        fgrTemplate fingerprint = new fgrTemplate()
                        {
                            ID = sd.GetInt32(0),
                            StudentID = sd.GetInt32(1),
                            Description = sd.GetString(2)
                            //Template = sd.GetByte(3)
        
                        };
                        yield return fingerprint;
        
                    }
        
                    cn.Close();
