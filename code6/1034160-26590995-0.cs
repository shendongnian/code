    public class Job
    {
        public Job(DateTime startDate)
        {
            this.StartDate = startDate;
        }
        public Job() : this(DateTime.UtcNow)
        {
        }
        public DateTime StartDate { get; private set; }
    }
