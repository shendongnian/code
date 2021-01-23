    string sourceFileName = "input.txt";
    string targetFileName = "output.txt";
    
    using (StreamWriter targetWriter = new StreamWriter(targetFileName))
    using (FileStream sourceStream = File.OpenRead(sourceFileName))
    {
        HashSet<string> processedKeys = new HashSet<string>();
        while (sourceStream.Position < sourceStream.Length)
        {
            string line = ReadLine(sourceStream);
            if (line.Length < 8)
                targetWriter.WriteLine(line);
            else
            {
                string key = line.Substring(0, 8);
                if (processedKeys.Contains(key))
                    continue;
                targetWriter.Write(line);
                long backupPosition = sourceStream.Position;
                while (sourceStream.Position < sourceStream.Length)
                {
                    string dupLine = ReadLine(sourceStream);
                    if (dupLine.Length < 8)
                        continue;
                    string dupKey = dupLine.Substring(0, 8);
                    if (dupKey == key)
                        targetWriter.Write(" " + dupLine);
                }
                sourceStream.Position = backupPosition;
                targetWriter.WriteLine();
                processedKeys.Add(key);
            }
        }
    }
