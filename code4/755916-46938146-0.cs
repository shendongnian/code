    public class Person
    {
      public int Id { get; set; }
      public string name { get; set; }
      public int? PetId { get; set; }
      public Pet Pet { get; set; }
    }
    public class Pet 
    {
      public string name { get; set; }
    }
    
    using (var db = new dbContext())
    {
      var person = db.Persons.FirstOrDefaultAsync(p => p.id == 1);
    }
    Console.WriteLine(person.Pet.Name);
