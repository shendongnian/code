    class Program
    {
        private static List<FooClass> fooDB;
        static void Main(string[] args)
        {
          initFromFile();
          foreach(FooClass f in fooDB)
          {
              // do something
          }
        }
    
        private static initFromFile()
        {
           fooDB = new List<FooClass>();
           using (StreamReader ... )
           {
              while( ... )
              {
                 ...
                 fooDB.Add(new FooClass(args))
              }
           }
         }//initFromFile
    
    }//Program
