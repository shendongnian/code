    public class Member
    {
        [Key]
        public int Id { get; set; }
    ...
    }
    public class Address : IEntity
    {
        [Key]
        public int Id { get; set; }
    
        public int MemberId {get;set;}
        public virtual Member Member {get;set;}
        ....
    }
