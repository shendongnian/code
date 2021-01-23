    void Main()
    {
      // some test data
      List<Person> ourList = new List<Person>() 
      {
        new Person() { ID = 1, Name = "Tom" },
        new Person() { ID = 2, Name = "Dick" },
        new Person() { ID = 3, Name = "Harry" },
        new Person() { ID = 4, Name = "Hogan" },
        new Person() { ID = 5, Name = "Arron" },
        new Person() { ID = 6, Name = "Tippu" },
        new Person() { ID = 7, Name = "Bernard" },
        new Person() { ID = 8, Name = "Long" },
        new Person() { ID = 9, Name = "Tippu Too" },
        new Person() { ID = 10, Name = "Unknown" }
      };
      
      // what we will use to order
      List<int> orderArray = new List<int>(){10,5,3,9,2,8,6};
      
      // the linq to do the ordering
      var result = ourList.OrderBy(e => {
         int loc = orderArray.IndexOf(e.ID);
         return loc == -1? int.MaxValue: loc;
      });
      
      // good way to test using linqpad (get it at linqpad.com
      result.Dump();
    }
    
    // test class so we have some thing to order
    public class Person
    {
       public int ID { get; set; }
       public string Name { get; set; }
    }
