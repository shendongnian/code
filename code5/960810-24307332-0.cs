    public class Person
    {
       [SQLite.PrimaryKey, SQLite.AutoIncrement]
       public int Id { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string Status {get;set;}
      
       public Person()
       {
          this.Status = true;  //this will set it to true whenever Person class is initialized and will insert true always.
       }
    }
