    [Table]
    [DataContract]
    public class Person
    {
       [Column]
       [DataMember]
       public int Id { get; set;}
       [Column]  
       [DataMember]
       public string FirstName { get; set;}
       [Column]
       [DataMember]
       public string LastName { get; set;}
    }
