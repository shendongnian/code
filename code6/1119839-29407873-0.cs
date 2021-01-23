    using (StreamWriter sw = File.CreateText(fileName))
    {
        foreach (FileInfo file in todaysFiles)
        {
            var errorLines = File.ReadLines(file.FullName).Where(l => l.Contains("ERROR")).ToList();
            if (errorLines.Any())
            {
                sw.WriteLine("----- ERROR -----");
                sw.WriteLine(file.Name); //file name
                foreach (var errLine in errorLines)
                {
                    sw.WriteLine(errLine);
                }
                sw.WriteLine("----- ERROR -----");
            }
         }
    }
