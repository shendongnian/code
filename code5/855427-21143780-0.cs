    public interface Auditable
    {
        string    CreatedById { get; set; }
        DateTime? CreatedTime { get; set; }
        string    UpdatedById { get; set; }
        DateTime? UpdatedTime { get; set; }
    }
