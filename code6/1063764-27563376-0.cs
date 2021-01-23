    class Program
    {
        static void Main(string[] args)
        {
            string csvFile = "test.csv";
            if (!File.Exists(csvFile)) //Create a test CSV file
                CreateCSVFile(csvFile, 15000000, 15000);
            List<string> duplicates = GetDuplicates(csvFile); //Returns every line once
            Console.ReadKey();
        }
        static List<string> GetDuplicates(string filename)
        {
            Stopwatch sw = new Stopwatch();//just a timer
            List<HashSet<string>> lines = new List<HashSet<string>>(); //Hashset is very fast in searching duplicates
            HashSet<string> current = new HashSet<string>(); //This hashset is used at the moment
            lines.Add(current); //Add the current Hashset to a list of hashsets
            sw.Restart(); //just a timer
            Console.WriteLine("Reading File"); //just an output message
            foreach (string line in File.ReadLines(filename))
            {
                try
                {
                    if (!/*Remove the exclamation mark if you want get a distinct list of entries*/lines.TrueForAll(hSet => !hSet.Contains(line))) //Look for an existing entry in one of the hashsets
                        current.Add(line); //If line not found, at the line to the current hashset
                }
                catch (OutOfMemoryException ex) //Hashset throws an Exception by ca 12,000,000 elements
                {
                    current = new HashSet<string>() { line }; //The line could not added before, add the line to the new hashset
                    lines.Add(current); //add the current hashset to the List of hashsets
                }
            }
            sw.Stop();//just a timer
            Console.WriteLine("File distinct read in " + sw.Elapsed.TotalMilliseconds + " ms");//just an output message
            List<string> concatinated = new List<string>(); //Create a list of strings out of the hashset list
            lines.ForEach(set => concatinated.AddRange(set)); //Fill the list of strings
            return concatinated; //Return the list
        }
        static void CreateCSVFile(string filename, int entries, int duplicateRow)
        {
            StringBuilder sb = new StringBuilder();
            using (FileStream fs = File.OpenWrite(filename))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                Random r = new Random();
                string duplicateLine = null;
                string line = "";
                for (int i = 0; i < entries; i++)
                {
                    line = r.Next(1, 10) + ";" + r.Next(11, 45) + ";" + r.Next(20, 500) + ";" + r.Next(2, 11) + ";" + r.Next(12, 46) + ";" + r.Next(21, 501);
                    sw.WriteLine(line);
                    if (i % duplicateRow == 0)
                    {
                        if (duplicateLine != null && i < entries - 1)
                        {
                            sb.AppendLine(duplicateLine);
                            i++;
                        }
                        duplicateLine = line;
                    }
                }
            }
        }
    }
