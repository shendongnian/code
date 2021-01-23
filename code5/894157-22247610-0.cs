     public partial class MyContext : DbContext
        {
            static MyContext()
            {
                Database.SetInitializer<MyContext>(null);
            }
    
            public MyContext() : this("Name=MyContext")
            {
            }
    
            public MyContext(string name): base(name)
            {
                Configuration.LazyLoadingEnabled = false;
            }
            ...
    }
