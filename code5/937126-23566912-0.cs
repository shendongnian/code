    public class Board {
      public Board(String name, int contactCount) {
        Name = name;
        Contacts = new List<String>(contactCount);
      }
    
      public String Name { get; set; }
      public List<String> Contacts { get; set; }
      ...
    }
