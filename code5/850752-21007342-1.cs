    static void Main(string[] args)
    {
        List<FooClass> fooDB = new List<FooClass>;
        initFromFile(fooDB);
    }
    private static initFromFile(List<FooClass> fooDB)
    {
        using (StreamReader ... ) 
        {
            while( ... )
            {
                ...
                fooDB.Add(new FooClass(args))
            }
        }
    }
