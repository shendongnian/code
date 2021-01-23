    class Program
    {
        static void Main(string[] args)
        {
            var dt = new DataTable();  // fill data
            var jobs = new List<Job>();
            Parallel.ForEach(dt.AsEnumerable(), row => jobs.Add(JobFactory.GetJob(row)));
        }    
    }
        
    public class JobFactory
    {
        public static Job GetJob(DataRow d)
        {
            var j = new Job();
    
            // do processing here from data row to fill job object
            return j;
        }
    }
    
    public class Job
    {
    
    }
