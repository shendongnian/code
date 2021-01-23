    [Export]
    class Class1
    {
        public Class1()
        {
            throw new MyException("MyException has been thrown");
        }
    }
    
    [Export]
    class Class2
    {
        [ImportingConstructor]
        public Class2(Class1 class1)
        {
    
        }
    }
    
    static void Main(string[] args)
    {
        var catalog = new AggregateCatalog(
            new AssemblyCatalog(typeof (Class1).Assembly));
        CompositionContainer container = new CompositionContainer(catalog, true);
        try
        {
            Class2 class2 = container.GetExportedValue<Class2>();
        }
        catch (CompositionException ex)
        {
            foreach (var cause in ex.RootCauses)
            {
                var myError = cause as MyException;
    
                if (myError == null)
                    myError = cause.InnerException as MyException;
    
                if (myError != null)
                {
                    //do what you want
                }
            }
        }
    }
