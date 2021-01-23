               //create the connection
                string Query = "SELECT City, State " +
                                       " FROM tbl_Zip WHERE Zip=@zip";
                OleDbConnection Connection = new OleDbConnection(gs_ConnString);
                OleDbCommand Command = new OleDbCommand(Query, Connection);
                Command.Parameters.AddWithValue("@zip",tb_Zip.Text);
                Connection.Open();
                OleDbDataReader Reader;
                Reader = Command.ExecuteReader();
