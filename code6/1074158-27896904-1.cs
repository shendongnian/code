            using (SqlConnection Conection = new SqlConnection(StrConection))
            {
                Conection.Open();
                using (SqlCommand Command = new SqlCommand("SELECT * FROM Images;", Conection))
                {
                                  
                    SqlDataReader Reader = Command.ExecuteReader();
                    if(Reader.HasRows)
                    {
                        Reader.Read();
                        byte[] ImageBytes = (byte[])Reader[1];
                        MemoryStream ms = new MemoryStream(ImageBytes); 
                        picBox2.Image = Image.FromStream(ms);
                    }
                }
                Conection.Close();
            }
