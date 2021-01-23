      var ents = new DynamicCategory.StackOverflowEntities26957446All();
      // all root items loop
      foreach (var item in ents.C26957446_All.Where(x => x.C26957446_All2 == null))
      {
        Console.WriteLine("Id: {0} Name: {1}", item.id, item.name);
        PrintChildrenRecursively(item);
      }  
      static int i = 1; //level
      static void PrintChildrenRecursively (DynamicCategory.C26957446_All item)
      {
        foreach (var c in item.C26957446_All1)
        {
          Console.WriteLine("{2} Child Id: {0} Name: {1}", c.id, c.name, new string('\t', i));
        if (c.C26957446_All1.Count > 0)
        {
          i++;
          PrintChildrenRecursively(c);
          i--;
        }
        Console.WriteLine();
        }
      }
