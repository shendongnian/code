            DateTime tenMinutesAgo = DateTime.Now.AddMinutes(-10);
            string[] systemAFiles = System.IO.Directory.GetFiles(systemAPath);
            foreach (string files in systemAFiles)
            {
                DateTime lastWriteTime = System.IO.File.GetLastWriteTime(files);
                if (lastWriteTime > tenMinutesAgo) //produced after ten minutes ago
                {
                    //read file
                }
            }
