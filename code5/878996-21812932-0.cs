    public interface IAudit
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        string ModifiedBy { get; set; }
    }
    OrmLiteConfig.InsertFilter = (dbCmd, row) =>
    {
        var auditRow = row as IAudit;
        if (auditRow != null)
        {
            auditRow.CreatedDate = auditRow.ModifiedDate = DateTime.UtcNow;
        }
    };
    OrmLiteConfig.UpdateFilter = (dbCmd, row) =>
    {
        var auditRow = row as IAudit;
        if (auditRow != null)
        {
            auditRow.ModifiedDate = DateTime.UtcNow;
        }
    };
