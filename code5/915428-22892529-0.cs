    public static class Program
    {
        internal static string Result(string ip)
        {
           // your function here
        }
    
        internal static void Main()
        {
            var ips = File.ReadAllLines("your.data");
    
            var results = ips.AsParallel().Select(Result).ToList();
    
            File.WriteAllLines("your.results", results);
        }
    }
