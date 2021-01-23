    public enum JobStatus
    {
        [Description("Job is Closed")]
        Closed,
        [Description("Job Had Error")]
        Error
    }
    public class Job
    {
        public JobStatus Status { get; set; }
        public void Report()
        {
            switch(Status)
            {
                case JobStatus.Closed:
                    // handle closed
                    break;
                case JobStatus.Error:
                    // handle error
                    break;
            }
            Console.WriteLine( Status.GetDescription() );
            // Prints "Job Had Error"
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var job=new Job();
            job.Status=JobStatus.Error;
            job.Report();
        }
    }
    public static class Extensions
    {
        public static string GetDescription(this Enum value)
        {
            Type type=value.GetType();
            var field=type.GetField(value.ToString());
            if(field!=null)
            {
                var attr=field.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
                if(attr.Length>0)
                {
                    return attr[0].Description;
                }
            }
            return string.Empty;
        }
    }
