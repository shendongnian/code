    public interface IDbAuditable : IDbEntity
    {
        Guid CreatedById { get; set; }
        DateTime CreatedOn { get; set; }
        Guid ModifiedById { get; set; } 
        DateTime ModifiedOn { get; set; }
        Guid? DeletedById { get; set; } 
        DateTime? DeletedOn { get; set; } 
    }
