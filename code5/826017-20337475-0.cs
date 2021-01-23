    public class MyClass
    {
        public int ID { get; set; }
        public List<MyDerivedClass> Objects { get; set; }
    }
    static void Main(string[] args)
    {
        Database.SetInitializer<MyClasses>(new DropCreateDatabaseIfModelChanges<MyClasses>());
        var myClass = new MyClass()
        {
            ID = 0,
            Objects = new List<MyBaseClass>()
            {
                //new MyBaseClass()
                new MyDerivedClass()
                {
                    //ID = 0,
                    Name = "My Test Object 1"
                },
                //new MyBaseClass()
                new MyDerivedClass()
                {
                    //ID = 1,
                    Name = "My Test Object 2"
                }
            }
        };
