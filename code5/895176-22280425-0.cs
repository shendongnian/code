    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetFullPath(args[0]);
            Console.WriteLine("trying path: " + path);
            if (Directory.Exists(path)){
                var files = Directory.GetFiles(path);
                foreach (var file in files) Console.WriteLine(file);
            }
            else
                Console.WriteLine("path doesn't exist");
        }
    }
