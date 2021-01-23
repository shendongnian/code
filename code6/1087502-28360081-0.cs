    public class DataService : IDataService
    {
        public virtual Employee TestMethodA()
        {
            return new Employee() {Id = 10, Name = "Montu Pradhan"};
        }
  
    }
    
    public class TestableDataService : DataService
    {
        private Employee e;
        public TestableDataService(Employee returningEmployee)
        {
            this.e = returningEmployee;
        }
        public override Employee TestMethodA()
        {
            return e;
        }
    }
