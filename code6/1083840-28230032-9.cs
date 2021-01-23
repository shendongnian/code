    class Program
    {
        static void Main(string[] args)
        {
            var path = args.FirstOrDefault(a => !String.IsNullOrEmpty(a)) ?? @"C:\Documents\Videos";
            args = args.Skip(1).ToArray();
            var pattern = args.FirstOrDefault(a => !String.IsNullOrEmpty(a)) ?? "*.mp4";
            var tree = Tree.CreateTree(path, null, pattern);
            Console.WriteLine((tree.ToDataTable() as TreeDataTable).ToXml());
        }
    }
