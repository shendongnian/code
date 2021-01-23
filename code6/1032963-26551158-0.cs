    public class User : IIdentifiableEntity
    {
       public int UserId {get; set;}
       //other properties...
       public int Id { get { return UserId; } set { UserId = value; } } 
    }
