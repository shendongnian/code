    public bool LookupExistence(string sSQL)
        {
            //bool bReturn;
            // Applying the "using" both opens and closes the connection.
            // There is no need to dispose of the connection with this approach.
            using (OdbcConnection oOdbcConnection = new OdbcConnection())
            {
                OdbcCommand oOdbcCommand = new OdbcCommand(); 
                //bool bReturn;
                //Open the connection and execute the insert command.
                try
                {
                    bool bReturn;
                    OdbcDataReader oDataReader;
                    bReturn = false;
                    oOdbcCommand = new OdbcCommand(sSQL, oOdbcConnection);
                    oOdbcCommand.CommandType = CommandType.Text;
                    oDataReader = oOdbcCommand.ExecuteReader();
                    if (oDataReader.HasRows)
                    {
                        bReturn = true;
                    }
                    return bReturn;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    bool bReturn = false;
                    return bReturn;
                }
            }
        }
       public void ExecuteDML(string sSQL)
        {
            // Applying the "using" both opens and closes the connection.
            // There is no need to dispose of the connection with this approach.
            using (OdbcConnection oOdbcConnection = new OdbcConnection())
            {
                OdbcCommand oOdbcCommand = new OdbcCommand();
                //Open the connection and execute the insert command.
                try
                {
                    oOdbcCommand = new OdbcCommand(sSQL, oOdbcConnection);
                    oOdbcCommand.CommandType = CommandType.Text;
                    oOdbcCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
