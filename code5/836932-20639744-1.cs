    public static IASet<T> GetIt<T>() 
      where T : IItem
    {
      ASet a = new ASet();
      a.Collection = new HashSet<OneItem>();
      a.Collection.Add(new OneItem() { Name = "one" });
      a.Collection.Add(new OneItem() { Name = "two" });
      //for test :
      foreach (var i in a.Collection)
      {
        Console.WriteLine(i.Name);
      }
      /*Error 1   Cannot implicitly convert type 'ConsoleApplication2.Program.ASet'
       * to 'ConsoleApplication2.IASet<ConsoleApplication2.IItem>'. An explicit
       * conversion exists (are you missing a cast?)
      */
      //return a;
      /*Unable to cast object of type 'ASet' to type
       * 'ConsoleApplication2.IASet`1[ConsoleApplication2.IItem]'.
       */
      return (IASet<T>)a;
    }
