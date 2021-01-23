    public class Header
    {
       public Header()
       {
          Operation= new List<Operation>();
       }
       [BsonId]
       public Codes Id {get; set;}
       public Int64 Code2 {get; set;}
       public string Name { get; set; }
       public List<Operation> Operations { get; set; }
    }
    public class Codes {
       public Int64 Code1 {get; set;}
       public Int64 Code2 {get; set;}
    } 
