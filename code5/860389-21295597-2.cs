    public interface IAuditCreated
    {
       DateTime CreatedDateTime { get; set; }
       string CreationUser { get; set; }
    }
    public interface IAuditChanged
    {
       DateTime LastChangeDateTime { get; set; }
       string LastChangeUser { get; set; }
    }
