    void Main()
    {
       List<record> data = new List<record> {
        new record() { ID = 1, Name = "Mike", Address = "100, Francis Dr, PA" },
        new record() { ID = 1, Name = "Mike", Address = "2, Richmond Street, PA" },
        new record() { ID = 2, Name = "John", Address = "45, Francis Dr, PA" },
        new record() { ID = 2, Name = "John", Address = "55, Richmond Street, PA" },
        new record() { ID = 3, Name = "Peter", Address = "23, Castle Street, PA" } };
       
       var result
         = data.GroupBy((x) => new { ID =x.ID, Name = x.Name })
            .Select((x) => 
               new { ID = x.Key.ID,
                     Name = x.Key.Name,
                     Addr1 = x.Take(1).Select((z) => z.Address).FirstOrDefault(),
                     Addr2 = x.Skip(1).Select((z) => z.Address).FirstOrDefault()});
      
    }
    
    // Define other methods and classes here
    public class record
    {
       public int ID { get; set; }
       public string Name { get; set; }
       public string Address { get; set; }
    }
