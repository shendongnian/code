        static void Main(string[] args)
        {
            const string directory = "files";
            IEnumerable<string> files = FindFiles(directory).ToList();
            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            var tasks = files.Select(f => ProcessOneFileAsync(f)).ToArray();
            Task.WaitAll(tasks);
            chrono.Stop();
            foreach (var t in tasks)
            {
                Console.WriteLine(t.Result);
            }
            Console.WriteLine(chrono.ElapsedMilliseconds);
            Console.ReadKey();
        }
        private static IEnumerable<string> FindFiles(string directoy)
        {
            return Directory.GetFiles(directoy).ToList();
        }
        private static async Task<Tuple<string, int>> ProcessOneFileAsync(string name)
        {
            int sum = 0;
            using (TextReader file = File.OpenText(name))
            {
                String line = null;
                while ((line = await file.ReadLineAsync()) != null)
                {
                    sum += line.Split(' ').Length;
                }
            }
            return new Tuple<string, int>(name, sum);
        }
