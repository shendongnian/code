    // Don't know if you need this one or if you want to have the class of joinedEntities always being the same
    public interface IJoinedEntities
    {
        int Id { get; set; }
    }
    public interface IRelatedEntity
    {
        int CId { get; set; }
    }
