         //Public variable to manage file names
        int FileCounter = 1;
        string FileName;
        
        // Call this function to Add text to file
        private void WriteToFile(string writeText)
        {
            FileName = "MyFile_"+FileCounter +".txt";
            if (File.Exists(FileName))
            {
                string str = File.ReadAllText(FileName);
                if ((str.Length + writeText.Length) / 1024 > 500)  // check for limit
                {
                    // Create new File
                    FileCounter++;
                    FileName = "MyFile_" + FileCounter + ".txt";
                    StreamWriter _sw = new StreamWriter(FileName, true);
                    _sw.WriteLine(writeText);
                    _sw.Close();
                    
                }
                else  // use exixting file
                {
                    StreamWriter _sw = new StreamWriter(FileName, true);
                    _sw.WriteLine(writeText);
                    _sw.Close();
                }
            }
        }
