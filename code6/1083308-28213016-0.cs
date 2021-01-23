    static object obj = new object();
                static void WriteOnFile(byte[] data)
                { 
                    lock(obj)
                    {
                      FileStream file_write = new FileStream(ileName,FileMode.Open, FileAccess.ReadWrite);
                      file_write.Write(data,0,data.Length);
                      file_write.Close();
                    }
                }
