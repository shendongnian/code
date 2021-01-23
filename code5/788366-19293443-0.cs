                string filePath = "test.txt";
                string[] lines = File.ReadAllLines(FilePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = lines[i].Replace("here", "here ADDED TEXT");
                }
    
                File.WriteAllLines(filePath, lines);
