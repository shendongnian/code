    public static void Test()
        {
            int cIdentity = 0;
    
            SqlConnection cConnection = new SqlConnection("...");
            cConnection.Open();
    
            SqlCommand cCommand = new SqlCommand("Insert INTO TestTable (Name) VALUES ('Test'); "+
                "SELECT @@IDENTITY AS Ident", cConnection);
    
            IDataReader cReader = null;
    
            try
            {
                cReader = cCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (cReader.Read())
                {
                    cIdentity = cReader.GetInt32(0);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                if (cReader != null)
                {
                    cReader.Close();
                }
            }
            finally
            {
                if (cConnection != null)
                {
                    cConnection.Close();
                }
            }
        }
