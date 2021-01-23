    public void Import(string csvfname)
    {
        string password;
        string cacheDatabase;
        string connectionString;
        System.IO.StreamReader objFile;
        string strCommand;
        string lineHeader;
        string line;
        string[] arrLineData;
        cacheDatabase = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "\\MyDatabase.sdf"; ;
        password = "";
        connectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", this.cacheDatabase, this.password);
        objFile = new System.IO.StreamReader(csvfname);
        lineHeader = objFile.ReadLine();
        while (!objFile.EndOfStream)
        {
            line = objFile.ReadLine();
            arrLineData = line.Split(',');
            try
            {
                sqlConnection = new SqlCeConnection(connectionString());
                strCommand = "INSERT INTO MyTable VALUES ('" + arrLineData[0] + "', '" + arrLineData[1] + "', '" + arrLineData[2] + "')";
                SqlCeCommand sqlCommand = new SqlCeCommand(strCommand, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error in Import(): " + exc.Message);
            }
        }
    }
