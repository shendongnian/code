    public class AuditViewModel
    {
        public AuditViewModel()
        {
            this.ExistingRecords = new List<EODAuditModel>();
        }
        public string Name { get; set; }
        public List<EODAuditModel> ExistingRecords { get; set; }
    }
