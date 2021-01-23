        private void button2_Click(object sender, EventArgs e)
        {
            string errorInfo = String.Empty;
            //open text file into Dataset:
            string textFilePath = @"textfile1.csv";
            DataSet dataTextFile = new DataSet("textfile");
            if(!LoadTextFile(textFilePath, dataTextFile, out errorInfo))
            {
                MessageBox.Show("Failed to load text file:\n" + errorInfo,
                    "Load Text File");
                return;
            }
            dgTextFile.DataSource = dataTextFile.Tables[0];
            dataTextFile.Dispose();	
        }
        private bool LoadTextFile(string textFilePath, DataSet dataToLoad, out string errorInfo)
        {
            errorInfo = String.Empty;
            try
            {
                string textFileFolder = (new System.IO.FileInfo(textFilePath)).DirectoryName;
                string textConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                                                "Data Source=" + textFileFolder + ";" +
                                                "Extended Properties=\"text;\";";
                OleDbConnection textConnection = new OleDbConnection(textConnectionString);
                textConnection.Open();
                textFilePath = (new System.IO.FileInfo(textFilePath)).Name;
                string selectCommand = "select * from " + textFilePath;
                //open command:
                OleDbCommand textOpenCommand = new OleDbCommand(selectCommand);
                textOpenCommand.Connection = textConnection;
                OleDbDataAdapter textDataAdapter = new OleDbDataAdapter(textOpenCommand);
                int rows = textDataAdapter.Fill(dataToLoad);
                textConnection.Close();
                textConnection.Dispose();
                return true;
            }
            catch(Exception ex_load_text_file)
            {
                errorInfo = ex_load_text_file.Message;
                return false;
            }
        }
