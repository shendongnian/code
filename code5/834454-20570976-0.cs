    public class Parent {
      public int Id { get; set; }
      // Additional properties
      public virtual List<Child> Children { get; set; }
    }
    
    public class Child {
      public int Id { get; set; }
      public string Prop1 { get; set; }
      public int ParentId { get; set; }
      public Parent Parent { get; set; }
    }
    
    public Database : DbContext {
      public DbSet<Parent> Parents { get; set; }
      public DbSet<Child> Children { get; set; }
    }
