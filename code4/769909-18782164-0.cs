    using System.IO;
    using System.Linq;
    public static class Program { 
        public static void Main()
        {
            var all = Directory.GetFiles("/tmp", "*.cpp")
                 .SelectMany(File.ReadAllLines);
            using (var w = new StreamWriter("/tmp/output.txt"))
                foreach(var line in all)
                    w.WriteLine(line);
        }
    }
