            bool NewRecordingExists;
            string dirPath = @"c:\recordings\";
            string[] fileNames = Directory.GetFiles(dirPath, "*.wma", SearchOption.TopDirectoryOnly);
            if (fileNames.Length != 0)
            {
                NewRecordingExists = true;
                foreach (string fileName in fileNames)
                {
                    Console.WriteLine("New Recording exists: {0}", fileName);
                    /*  do you process for each file here */
                }
            }
            else
            {
                NewRecordingExists = false;
                Console.WriteLine("No New Recording exists");
                System.Threading.Thread.Sleep(300000);
            }
