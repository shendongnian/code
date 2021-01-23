    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            Console.WriteLine("trying path: " + path);
            if (Directory.Exists(path))
                Directory.GetFiles(path).ToList().ForEach(s => Console.WriteLine(s));
            else
                Console.WriteLine("path not found");
        }
    }
