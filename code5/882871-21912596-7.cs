    public class PocoWithDates : IEntityAutoDateFields
    {
        public PocoWithDates()
        {
        }
    
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
