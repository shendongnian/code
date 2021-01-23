    public interface IEntity
    {
        int ID { get; set; }
        OrgTypes Type { get; } // Only getter, classes must know their own type.
        string Name { get; set; }
        IEntity Parent { get; set; }
    }
    
