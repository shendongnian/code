    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetFqTypeName("IMyInterface"));
            Console.ReadKey();
        }
        static String GetFqTypeName(string shortTypeName)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .ToList()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.Name == shortTypeName)
                .Select(x => x.FullName)
                .FirstOrDefault();
        }
    }
    public interface IMyInterface { }
