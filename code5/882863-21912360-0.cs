    public class PocoWithDates {
        public PocoWithDates()
        {
            this.DateCreated = DateTime.Now;
            this.DateUpdated = this.DateCreated;
        }
        public string PocoName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
