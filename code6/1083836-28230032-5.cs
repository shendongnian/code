    class Program
    {
        static void Main(string[] args)
        {
            var path = args.FirstOrDefault(a => !String.IsNullOrEmpty(a)) ?? @"C:\Documents\Videos";
            args = args.Skip(1).ToArray();
            var pattern = args.FirstOrDefault(a => !String.IsNullOrEmpty(a)) ?? "*.mp4";
            Console.WriteLine(Tree.CreateTree(path, null, pattern));
            Console.ReadKey();
        }
    }
