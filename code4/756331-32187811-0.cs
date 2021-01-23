      private string GetMemoField(string TableName, string FieldName, string IdentityFieldName, string IdentityFieldValue, OleDbConnection conn)
        {
            string ret = "";
            OleDbCommand cmd1 = new OleDbCommand("SELECT " + FieldName + " FROM “ + TableName + “ WHERE " + IdentityFieldName + "=" + IdentityFieldValue, conn);
                    var reader = cmd1.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);  // Create the DataReader that will get the memo field one buffer at a time
            if (reader.Read())
            {
                long numberOfChars = reader.GetChars(/*Field pos*/ 0, 0, null, 0, 0);   // Total number of memo field's chars
                if (numberOfChars > 0)
                {
                    int bufferSize = 1024;
                    char[] totalBuffer = new char[64*bufferSize];    // Array to hold memo field content
                    long dataIndex = 0;
                    do
                    {
                        char[] buffer = new char[bufferSize];   // Buffer to hold single read
                        long numberOfCharsReaded = reader.GetChars(0, dataIndex, buffer, 0, bufferSize);
                        if (numberOfCharsReaded == 0)
                        {
                            ret = new string(totalBuffer,0, (int)numberOfChars);
                            break;
                        }
                        Array.Copy(buffer, 0, totalBuffer, dataIndex, numberOfCharsReaded);     // Add temporary buffer to main buffer
                        dataIndex += numberOfCharsReaded;
                    } while (true);
                }
            }
            return ret;
        }
