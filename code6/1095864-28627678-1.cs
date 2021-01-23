    public Car 
    {
        public int ID { get; set; }
        public string Brand {get; set; }
        public int Driver1ID {get; set;}
        public Person Driver1 {get; set;}
        public int Driver2ID {get; set;}
        public Person Driver2 {get; set;}
    }
    
    public Person
    {
       public int ID { get; set; }
       public string Name { get; set; }
    }
    
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder) { 
    // ....
    modelBuilder.Entity<Car>().HasKey(x => x.ID);
    modelBuilder.Entity<Car>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // set it on
    modelBuilder.Entity<Car>().HasRequired(x => x.Driver1).WithMany().HasForeignKey(x => x.Driver1ID).WillCascadeOnDelete(false);
    modelBuilder.Entity<Car>().HasRequired(x => x.Driver2).WithMany().HasForeignKey(x => x.Driver2ID).WillCascadeOnDelete(false);
    // ....
    }
