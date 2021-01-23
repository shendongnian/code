    private static initFromFile(ref List<FooClass> fooDB)
    {
      fooDB = new List<FooClass>; // if the parameter was not passed by reference 
                                   // this instance would not be used by the caller.
      using (StreamReader ... ){
      while( ... )
      {
        ...
        fooDB.Add(new FooClass(args))
      }}
    }//initFromFile
