        const string f = @"C:\test.txt";
        static void Main(string[] args)
        {
            // 1
            // Declare new List.
            List<string> lines = new List<string>();
            // 2
            // Use using StreamReader for disposing.
            using (StreamReader r = new StreamReader(f))
            {
                // 3
                // Use while != null pattern for loop
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    // 4
                    // Insert logic here.
                    // ...
                    // "line" is a line in the file. Add it to our List.
                    if (line.Trim() == "")
                        continue;
                    if (line == null)
                        continue;
                    lines.Add(line);
                }
            }
            // 5
            string stringValue = "two";
            int correctIndex = -1;
            // Print out all the lines.
            for (int i=0; i<lines.Count; i++)
            {
                if (lines[i].Contains(stringValue))
                {
                    correctIndex = i;
                }
            }
            if(correctIndex == -1)
            {
                Console.WriteLine("item is not found");
            }
            else
            {
                //here you will need probably little more cleaning of the string. If the strings are on 1 line you should search for lines[correctIndex]
                Console.WriteLine(lines[correctIndex + 1]);
            }
        }
    }
