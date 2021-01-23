    public interface IAuditableEntity
    {
        DateTime CreatedDateUtc { get; set; }
        DateTime ModifiedDateUtc { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
    }
