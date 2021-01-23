        private static IEnumerable<int> GenerateList()
        {
            for (var i=0; i <= 10000; i++)
                yield return i;
        }
        private const string Path = "1";
        
        private static string DoSomeComplicatedModificationOnNode(int node)
        {
            return node.ToString(CultureInfo.InvariantCulture);
        }
        private static string MapToString( int node)
        {
            Console.WriteLine("Thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            try
            {
                string temp = DoSomeComplicatedModificationOnNode(node);
                if (temp.ToLower().Contains(Path))
                {
                    return temp;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
        private static void Main(string[] args)
        {
            var result =
                GenerateList()
                    .AsParallel()
                    .Select(MapToString)
                    .Where(x => !String.IsNullOrWhiteSpace(x))
                    .ToList();
            Console.ReadKey();
        }
