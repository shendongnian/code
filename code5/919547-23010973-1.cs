        static void Main(string[] args)
        {
            var files = GetFilePaths("*Hello*", "C:\\");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
        public static IEnumerable<string> GetFilePaths(string pattern, string directory)
        {
            return Directory.GetFiles(directory, pattern, SearchOption.AllDirectories);
        }
