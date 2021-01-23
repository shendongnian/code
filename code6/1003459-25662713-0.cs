    // extra class is having an int property containig the foreign key
    public class UserAdditionalData
    {
        public virtual int UserId { get; set; }
    }
    
    // that would be the mapping:
    public UserExtraMapping()
    {
        ...
        Map(x => x.UserId, "USERID");
    }
