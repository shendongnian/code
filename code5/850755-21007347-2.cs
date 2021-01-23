    class Program
    {
        private static List<FooClass> fooDB;
        static void Main(string[] args)
        {
          initFromFile();
          foreach(FooClass f in this.fooDB)
          {
              // do something
          }
        }
    
        private static initFromFile()
        {
           this.fooDB = new List<FooClass>();
           using (StreamReader ... )
           {
              while( ... )
              {
                 ...
                 this.fooDB.Add(new FooClass(args))
              }
           }
         }//initFromFile
    
    }//Program
