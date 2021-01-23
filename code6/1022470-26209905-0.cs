    public class Permit
    {
        public Permit()
        {
            this.PermitId = Guid.NewGuid().ToString();
        }
        public string PermitId { get; set; }
        public ICollection<OfficePermit> OfficePermits { get; set; }
    }
    public class OfficePermit   
    {
        public OfficePermit()
        {
            this.OfficePermitId = Guid.NewGuid().ToString();
        }
        public string OfficePermitId { get; set; }
        public string PermitId { get; set; }
        public Permit Permit { get; set; }
        public ICollection<@Task> Tasks { get; set; }
    }
    public class @Task
	{
        public Task()
        {
            this.TaskId = Guid.NewGuid().ToString();
        }
        public string TaskId { get; set; }
        public OfficePermit OfficePermit { get; set; }
        public string OfficePermitId { get; set; }
	}
