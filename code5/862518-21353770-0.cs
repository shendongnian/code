    public class Program
    {
        public static void Main()
        {
            var jobService = new JobService(new Repository()); 
    
            Console.WriteLine("Creating job banker, creation:");
    
            Job jobBanker = jobService.CreateJobBanker();
    
            Console.WriteLine("Job banker: {0}", jobBanker);
        }
    }
