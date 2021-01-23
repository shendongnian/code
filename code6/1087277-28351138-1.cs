      class Program
    {
        static void Main(string[] args)
        {
            var sync = new Object();
            var dt = new DataTable();  // fill data
            var jobs = new List<Job>();
            Parallel.ForEach(dt.AsEnumerable(), row =>
            {
                var job = JobFactory.GetJob(row);
                lock (sync)
                {
                    jobs.Add(job);
                }
            });
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
