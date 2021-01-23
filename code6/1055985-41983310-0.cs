    public class Person {
       public int Id {get;set;}
       public string Name {get;set;}
       public DateTime Birthday {get;set;}
       public string BirthdayFormat { get {
          return Birthday.toString("dd/MM/YYYY")
       }}
    }
