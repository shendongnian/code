        static void Main(string[] args)
        {
            List<string> files = new List<string>();
            files.Add("C:\\XMLFiles\\1.xml");
            files.Add("C:\\XMLFiles\\2.xml");
            ConsolidateFiles(files, "C:\\XMLFiles\\Result.xml");
            Console.ReadLine();
        }
        private static void ConsolidateFiles(List<String> files, string outputFile)
        {
            using (var output = new StreamWriter(outputFile))
            {
                output.WriteLine("<Data>");
                foreach (var file in files)
                {
                    using (var input = new StreamReader(file, FileMode.Open))
                    {
                        while (!input.EndOfStream)
                        {
                            string line = input.ReadLine();
                            if (!line.Contains("<Data>") &&
                                !line.Contains("</Data>"))
                            {
                                output.Write(line);
                            }
                        }
                    }
                }
                output.WriteLine("</Data>");
            }
        }
