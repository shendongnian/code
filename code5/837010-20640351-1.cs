    private static void WriteFile(string mySearchString, string fileToWrite, params string[] filesToRead)
    {
        using (var sw = new StreamWriter(fileToWrite, true))
        {
            var count = 1;
    
            foreach (var file in filesToRead)
            {
                using (var sr = new StreamReader(file))
                {
                    string line;
    
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (count == 3)
                        {
                            sw.WriteLine(line);
                        }
                        if (count > 3 && line.Contains(mySearchString))
                        {
                            sw.WriteLine(line);
                        }
    
                        count++;
                    }
                }
            }
        }
    }
