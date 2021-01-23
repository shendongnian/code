    public class Person
    {
        public int Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public List<Book> Books {get;set}
    } 
    
    public class Book
    {
        public int Id {get;set;}
        public string Name {get;set;}        
    }
