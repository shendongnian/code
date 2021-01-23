    public class Activity {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [IgnoreDataMember]
        public virtual Employee OpenedBy { get; set; }
    }
