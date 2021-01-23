    private static readonly CompositionContainer _container;
    
    static ObjectFactory()
    {       
        var directoryCatalog = new DirectoryCatalog(Environment.CurrentDirectory)
        _container = new CompositionContainer(directoryCatalog);        
    }
    public static IClass CreateObject(ObectType objectType)
    {       
        var objectTypes objectTypes = new List<Lazy<IClass, IMetaData>>();
        try
        {
           objectTypes.AddRange(_container.GetExports<IClass, IMetaData>());
        }
        catch (CompositionException compositionException)
        {
            Console.WriteLine(compositionException.ToString());
            Console.ReadLine();
        }
        return objectTypes.FirstOrDefault(x => x.Metadata.Type == objectType.ToString());
    }
    
