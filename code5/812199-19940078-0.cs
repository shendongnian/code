    class Program
    {
        public static List<string> fileExtenstions
        {
            get
            {
                return new List<string>
                {
                    ".xml",
                    ".dat",
                    ".txt",
                    ".csv",
                    ".zip",
                    ".doc"
                };
            }
        }
        public static string outputDirecotry = @"C:DebugCopy";
        public static void Main()
        {
            var filesToCopy = Directory.EnumerateFiles(@"C:Debug")
                .Where(path => fileExtenstions.Contains(Path.GetExtension(path).ToLower()));
            foreach (var path in filesToCopy.Where(File.Exists))
                File.Copy(path , Path.Combine(outputDirecotry , Path.GetFileName(path)));
        }
    }
