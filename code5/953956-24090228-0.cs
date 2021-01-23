    public class Repository 
    {
        private readonly TestContext _testContext;
        public Repository()
        {
            _testContext = new TestContext();
        }
    
        public void Add<T>(T input) where T : Base
        {
           var kew =  _testContext.Set<T>().Add(input);
        }
    
        public void Save()
        {
            _testContext.SaveChanges();
        }  
    }
