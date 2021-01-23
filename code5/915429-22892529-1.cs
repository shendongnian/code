    public static class Program
    {
        internal static string Result(string ip)
        {
           // your function here
        }
    
        internal static void Main()
        {
            const int ParallelJobs = 100;
            var ips = File.ReadAllLines("your.data");
    
            var results = ips.AsParallel().WithDegreeOfParallelism(ParallelJobs ).Select(Result).ToList();
    
            File.WriteAllLines("your.results", results);
        }
    }
