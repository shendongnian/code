    public class MyTable : IAudit
    {
        // Your properties
        ...
        // The audit properties
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        string ModifiedBy { get; set; }
    }
