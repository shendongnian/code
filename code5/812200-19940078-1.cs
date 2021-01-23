    class Program : EqualityComparer<string>
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
                     .Where(path => fileExtenstions.Contains(Path.GetExtension(path))))
                File.Copy(path , Path.Combine(outputDirecotry , Path.GetFileName(path)));
        }
        public override bool Equals(string x, string y)
        {
            return x.Equals(y, StringComparison.InvariantCultureIgnoreCase);
        }
        public override int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
