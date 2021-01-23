           public static byte[] getpicture(int artikelnummer)
            {
                string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jeroen\Documents\Visual Studio 2010\Projects\producten\producten\App_Data\Bimsports.accdb;Persist Security Info=True";
                OleDbConnection conn = new OleDbConnection(connectionstring);
                //Execute
                string sql = "SELECT foto FROM Artikel WHERE Artikelnummer =?";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.AddWithValue("Artikelnummer", artikelnummer);
                try
                {
                    byte[] photodata = null;
                    conn.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
    
                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (!reader.IsDBNull(0))
                        {
                            photodata = new byte[Convert.ToInt32((reader.GetBytes(0, 0, null, 0, Int32.MaxValue)))];
                            long bytesreceived = reader.GetBytes(0, 0, photodata, 0, photodata.Length);
                        }
                    }
                    return photodata;
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    conn.Close();
                }
                return null;
            }
            public static bool SavePicture(int artikelnummer, byte[] photodata)
            {
                int rowupdated = 0;
    
                string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jeroen\Documents\Visual Studio 2010\Projects\producten\producten\App_Data\Bimsports.accdb;Persist Security Info=True";
                OleDbConnection conn = new OleDbConnection(connectionstring);
    
                string sql = "UPDATE Artikel SET foto=? WHERE artikelnummer=?";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
     
    
                conn.Open();
    
                OleDbParameter param = new OleDbParameter("@foto", OleDbType.VarBinary, photodata.Length);
                param.Value = photodata;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("Artikelnummer", artikelnummer);
                rowupdated = (int)cmd.ExecuteNonQuery();
    
                return (rowupdated>0);
    
            
            
            }
        }
    }
