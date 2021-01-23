        public List<TestClass> TestClasses { get; set; }
        public TestContext()
        {
            Debug.WriteLine(Database.Connection.ConnectionString);
            TestClasses = new List<TestClass>();
        }
    }
    public class TestClass
    {
        public int ClassId { get; set; }
        public String ClassName { get; set; }
        public String ClassDescription { get; set; }
    }
