    // DbSet property in your DbContext
    public DbSet<MyClass2> Classes { get; set; }
    // new derived class to use in place of MyClass
    public class MyClass2 :  MyClass
    {
        public virtual List<MyDerivedClass> DerivedObjects
        {
            get
            {
                return base.Objects.Cast<MyDerivedClass>().ToList();
            }
            set
            {
                Objects = value.Cast<MyBaseClass>().ToList();
            }
        }
    }
    static void Main(string[] args)
    {
        Database.SetInitializer<MyClasses>(new DropCreateDatabaseIfModelChanges<MyClasses>());
        var myClass = new MyClass2()
        {
            ID = 0,
            // use DerivedObjects, not Objects!
            DerivedObjects = new List<MyDerivedClass>()
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
