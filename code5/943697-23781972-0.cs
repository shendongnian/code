    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
    
    
      public long? ParentID { get; set; }
      public Category Parent { get; set; }
    }
    
    
    modelBuilder.Entity<Category>().
          HasOptional(c => c.Parent).
          WithMany().
          HasForeignKey(m => m.ManagerID);
