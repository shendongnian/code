    public class PocoWithDates : IEntityWithDateUpdated
    {
        public PocoWithDates()
        {
            this.DateCreated = DateTime.Now;
            this.DateUpdated = DateTime.Now;
        }
    
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
