    public class Role
    {
        public virtual int ID { get; set; }
        public virtual String Name { get; set; }
        public virtual String Description { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IncludeInReports { get; set; }
        public virtual bool IsDefault { get; set; }
    }
