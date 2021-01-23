    private static void WriteFile(string fileToRead, string fileToWrite, string mySearchString)
    {
        using (var sr = new StreamReader(fileToRead))
        using (var sw = new StreamWriter(fileToWrite, true))
        {
            var count = 1;
    
            while (sr.Peek() != -1)
            {
                var line = sr.ReadLine();
                
                if (count == 3)
                {
                    sw.WriteLine(line);
                }
                if (count > 3)
                {
                    if (line != null && line.Contains(mySearchString))
                    {
                        sw.WriteLine(line);
                    }
                }
    
                count++;
            }
        }
    }
