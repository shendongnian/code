        private static void ReadAllFilesStartingFromDirectory(string topLevelDirectory)
        {
            const string searchPattern = "*.txt";
            var subDirectories = Directory.EnumerateDirectories(topLevelDirectory);
            var filesInDirectory = Directory.EnumerateFiles(topLevelDirectory, searchPattern);
            foreach (var subDirectory in subDirectories)
            {
                ReadAllFilesStartingFromDirectory(subDirectory);//recursion
            }
            IterateFiles(filesInDirectory, topLevelDirectory);
        }
        private static void IterateFiles(IEnumerable<string> files, string directory)
        {
            foreach (var file in files)
            {
                Console.WriteLine("{0}", Path.Combine(directory, file));//for verification
                try
                {
                    string[] lines = File.ReadAllLines(file);
                    foreach (var line in lines)
                    {
                        //Console.WriteLine(line);   
                    }
                }
                catch (IOException ex)
                {
                    //Handle File may be in use...                    
                }
            }
        }
