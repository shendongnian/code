        public static System.IO.MemoryStream RetrieveMemoryStream(System.Data.IDbCommand cmd, string columnName, string path)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            using (System.Data.IDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess | System.Data.CommandBehavior.CloseConnection))
            {
                bool hasRows = reader.Read();
                if (hasRows)
                {
                    const int BUFFER_SIZE = 1024 * 1024 * 10; // 10 MB
                    byte[] buffer = new byte[BUFFER_SIZE];
                    int col = string.IsNullOrEmpty(columnName) ? 0 : reader.GetOrdinal(columnName);
                    int bytesRead = 0;
                    int offset = 0;
                    // Write the byte stream out to disk
                    while ((bytesRead = (int)reader.GetBytes(col, offset, buffer, 0, BUFFER_SIZE)) > 0)
                    {
                        ms.Write(buffer, 0, bytesRead);
                        offset += bytesRead;
                    } // Whend
                } // End if (!hasRows)
                reader.Close();
            } // End Using reader
            return ms;
        } // End Function RetrieveFile
