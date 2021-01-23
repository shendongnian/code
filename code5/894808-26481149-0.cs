    public partial class TestEntities : DbContext
        {
            public TestEntities()
                : base("name=TestEntities")
            {
            }
    
            public TestEntities(string sConnectionString)
                : base(sConnectionString)
            {
            }
    
    ...}
