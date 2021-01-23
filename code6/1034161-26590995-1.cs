    public class NewJob
    {
        public NewJob()
        {
            this.StartDate = DateTime.UtcNow;
        }
        public DateTime StartDate { get; private set; }
    }
