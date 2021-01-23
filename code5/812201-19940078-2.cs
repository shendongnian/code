    class Program 
    {
        public static string outputDirecotry = @"C:DebugCopy";
        public static void Main()
        {
            var fileExtenstions = new List<string>
                {
                    ".xml",
                    ".dat",
                    ".txt",
                    ".csv",
                    ".zip",
                    ".doc"
                };
            foreach (var path in Directory.EnumerateFiles(@"C:Debug")
                     .Where(path => fileExtenstions.Contains(Path.GetExtension(path).ToLower())))
                File.Copy(path , Path.Combine(outputDirecotry , Path.GetFileName(path)));
        }
    }
