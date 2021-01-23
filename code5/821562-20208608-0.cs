       List<string> lstDirName = new List<string>();
       private void processDirectory(string startLocation)
        {
            foreach (var directory in Directory.GetDirectories(startLocation))
            {
                if (Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0)
                {
                    lstDirName.Add(directory.Name);
                }
                processDirectory(directory);
            }
        }
