        private void Main()
        {
            var lines = ReadFile().Select(l => l.ToString()).ToList();
            
            // The short way, do them after each other
            lines.ForEach(Console.WriteLine);
            File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);
        }
