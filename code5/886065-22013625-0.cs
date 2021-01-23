    FileStream stream = new FileStream(textBox4.Text, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);
                byte[] file = reader.ReadBytes((int)stream.Length);
    
                reader.Close();
                stream.Close();
                string query = "UPDATE UPDATE_Z SET FILE_Z=? WHERE ID='"+1+"';";
    
                {
                    OleDbConnection connection = new OleDbConnection(conn);
                    connection.Open();
                    OleDbCommand command = connection.CreateCommand();
                    // command.CreateParameter();
    
                    command.CommandText = query;
    
                    command.Parameters.Add("FILE_Z", OleDbType.Binary, file.Length);
                    command.Parameters[0].Value = file;
                    command.ExecuteNonQuery();
                    connection.Close();
                   // for (int i=0; i < file.Length;i++ )
                    //{
                      // MessageBox.Show(file[i].ToString());
                    //}
    
                }
                query = "SELECT FILE_Z FROM UPDATE_Z where ID ='"+1+"'";
                FileStream stream1;
                BinaryWriter writer;
    
                int bufferSize = 100;
                byte[] outByte = new byte[bufferSize];
    
                long retval;
                long startIndex = 0;
    
                string pubID = "";
    
    
                OleDbConnection connection1 = new OleDbConnection(conn);
                connection1.Open();
                OleDbCommand command1 = connection1.CreateCommand();
                command1.CommandText = query;
                OleDbDataReader reader1 = command1.ExecuteReader(System.Data.CommandBehavior.Default);
    
    
    
                while (reader1.Read())
                {
                 //   pubID = reader1.GetString(0);
    
                    stream1 = new FileStream("version1.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    writer = new BinaryWriter(stream1);
                    startIndex = 0;
                   retval = reader1.GetBytes(0, startIndex, outByte, 0, bufferSize);
    
                    while (retval == bufferSize)
                    {
                        writer.Write(outByte);
                        writer.Flush();
                        startIndex += bufferSize;
                        retval = reader1.GetBytes(0, startIndex, outByte, 0, bufferSize);
                    }
                    writer.Write(outByte, 0, (int)retval);
                    writer.Flush();
    
                    writer.Close();
    
                    stream1.Close();
                }
    
                reader1.Close();
                connection1.Close();
