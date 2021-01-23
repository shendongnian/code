    public class UniqueIdentifiedObject
    {
        public Guid Id { get; set; }
    }
    public class User : UniqueIdentifiedObject 
    {
        // You don't need to stupidly repeat yourself (DRY)
    }
