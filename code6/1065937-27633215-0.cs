    class DataRetriever
    {
       BaseUrl="...";
    
       object obj=new object();
       public static void _Fetch(<list<dataInformation> quote)
       {
          lock(obj) // giving error obj is not accepting here
          {
             XDocument doc=XDocument.Load(BaseUrl);
             parse(quote,doc);
          }
       }
    
       private static void Parse(List<dataInformation> quotes, XDocument doc)
       {
           // some statement
       }
    }
