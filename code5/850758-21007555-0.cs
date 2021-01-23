    public Class FooClass
    {...}
    class Program
    {static void Main(string[] args)
    {
      var fooData = initFromFile();
    }
    
    private static List<FooClass> initFromFile()
    {
      var fooDB = new List<FooClass>();
    
      using (StreamReader ... ){
      while( ... )
      {
        ...
        fooDB.Add(new FooClass(args))
      }}
    
      return fooDB;
    }//initFromFile
    }//Program
