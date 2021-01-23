    void Main()
    {
        List<Person> Persons = new List<Person>()
           { new Person() { ID = 1, FirstName = "FName1", LastName = "LName1", PersianBirthDate = "1362/01/01"},
             new Person() { ID = 2, FirstName = "FName2", LastName = "LName2", PersianBirthDate = "1359/05/01"},
             new Person() { ID = 3, FirstName = "FName3", LastName = "LName3", PersianBirthDate = "1350/04/11"},
             new Person() { ID = 4, FirstName = "FName4", LastName = "LName4", PersianBirthDate = "1355/02/10"},
             new Person() { ID = 5, FirstName = "FName5", LastName = "LName5", PersianBirthDate = "1365/12/25"} };
    
        var result = Persons
                .Where(x=> { 
                   var z = x.PersianBirthDate.Split("/".ToCharArray());
                   return (new DateTime(int.Parse(z[0]),int.Parse(z[1]),int.Parse(z[2])) <=
                           new DateTime(1362,1,1)); });
                           
    }
    
    public class Person
    {
      public int ID { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string PersianBirthDate { get; set; }
    };
     
