    public class TestClass
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<TestSubClass> TestSubs {get;set;}
    }
    
    public class TestSubClass
    {
        [Key]
        public Guid Id { get; set; }
        public int Status { get; set; }
    
        [Column("Test")]
        public Guid? TestId { get; set; }
        [ForeignKey("TestId")]
        public virtual TestClass Test { get; set; }
    }
    
    public static IQueryable<TestClass> GetEverything(bool onlyVisible = false)
    {
          var context = new TestContext();
          var query = from test in context.TestClass
                    select test;
    
          if (onlyVisible)
          {
               query = query.Include(i => i.TestSubs).Where(w => w.TestSubs.Any(a => a.Status == 1));
          }
          return query;
    }
