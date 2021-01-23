    public class Plan
    {
        public Plan()
        {
            this.Dates = new List<DateTime>();
        }
        public virtual int Id { get; set; }
        public virtual IList<DateTime> Dates { get; set; }
    }
