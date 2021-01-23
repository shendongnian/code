            Regex splitter = new Regex(@"Key=([\w]+), Value=([\w]+)");
            
            string path = "TextFile1.txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            lines.ToList().ForEach((s) =>
            {
                Match match = splitter.Match(s);
                if (match.Success)
                {
                    Console.WriteLine("The Key is " + match.Groups[1] + " and the value is " + match.Groups[2]);
                }
            });
