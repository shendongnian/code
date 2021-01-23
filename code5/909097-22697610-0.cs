        static void Main(string[] args)
        {
            String path1 = @"C:\file1.txt";
            String path2 = @"C:\file2.txt";
            String newFilePath = @"C:\final.txt";
            // Open the file1 to read from. 
            string[] readText = File.ReadAllLines(path1);
            // Add file1 contents to dictionary (key is second value)
            Dictionary<string, string> dictionaryA = new Dictionary<string, string>();
            foreach (string s in readText)
            {
                string[] parts = s.Split('=');
                dictionaryA.Add(parts[1], parts[0]);
            }
            // Open the file2 to read from. 
            readText = File.ReadAllLines(path2);
            // Add file2 contents to dictionaryB (key is first value)
            Dictionary<string, string> dictionaryB = new Dictionary<string, string>();
            foreach (string s in readText)
            {
                string[] parts = s.Split('=');
                dictionaryB.Add(parts[0], parts[1]);
            }
            // Create output file
            System.IO.StreamWriter file = new System.IO.StreamWriter(newFilePath);
            // write each value to final.txt file
            foreach (var key in dictionaryA.Keys)
            {
                if (dictionaryB.ContainsKey(key))
                {
                    file.WriteLine(dictionaryA[key] + "=" + dictionaryB[key]);
                }
            }
            file.Close();
        }
