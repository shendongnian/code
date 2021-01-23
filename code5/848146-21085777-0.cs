    class Program
    {
        static void Main(string[] args)
        {
            string path = @"... myfile.msi";
            using (InstallPackage package = new InstallPackage(path, DatabaseOpenMode.ReadOnly))
            {
                foreach (var kvp in package.Files.Where(f => Path.GetExtension(f.Value.TargetName) == ".dll"))
                {
                    Console.WriteLine(kvp.Value.TargetName);
                }
            }
        }
    }
