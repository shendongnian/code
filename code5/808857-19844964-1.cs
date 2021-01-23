        private static void ReadAllFilesStartingFromDirectory(string topLevelDirectory)
        {
            IEnumerable<string> subDirectories = Directory.EnumerateDirectories(topLevelDirectory);
            
            foreach (var subDirectory in subDirectories)
            {
                ReadAllFilesStartingFromDirectory(subDirectory);//recursion
            }
            
            IEnumerable<string> files = Directory.EnumerateFiles(topLevelDirectory);
            foreach (var file in files)
            {
                Console.WriteLine("{0}", Path.Combine(topLevelDirectory,file));//sample output of file names for verification
                try
                {
                    string[] lines = File.ReadAllLines(file);
                    foreach (var line in lines)
                    {
                        //do work
                        //Console.WriteLine(line);   
                    }   
                }
                catch (IOException ex)
                {
                    //Handle File may be in use...                    
                }
            }
        }
