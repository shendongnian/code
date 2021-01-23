        // http://stackoverflow.com/questions/2885335/clr-sql-assembly-get-the-bytestream
        // http://stackoverflow.com/questions/891617/how-to-read-a-image-by-idatareader
        // http://stackoverflow.com/questions/4103406/extracting-a-net-assembly-from-sql-server-2005
        public static void RetrieveFileStream(System.Data.IDbCommand cmd, string columnName, string path)
        {
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
                    using (System.IO.FileStream bytestream = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
                    {
                        while ((bytesRead = (int)reader.GetBytes(col, offset, buffer, 0, BUFFER_SIZE)) > 0)
                        {
                            bytestream.Write(buffer, 0, bytesRead);
                            offset += bytesRead;
                        } // Whend
                        bytestream.Close();
                    } // End Using bytestream 
                } // End if (!hasRows)
                reader.Close();
            } // End Using reader
        } // End Function RetrieveFile
