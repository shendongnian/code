    foreach (var locGroup in grouping) {
      Console.WriteLine("LocId: " + locGroup.Key)
  
      foreach (var secGroup in locGroup) {
        Console.WriteLine("  SecId:" + secGroup.Key.SecId)
          Console.WriteLine("  Min StartElevation: {0}", 
            secGroup.Min(col => col.StartElevation);
          Console.WriteLine("  Max EndElevation: {0}", 
            secGroup.Max(col => col.EndElevation);
          foreach (var column in secGroup) {
            Console.WriteLine("    {0} -> {1}", column.StartElevation, column.EndElevation);
          }
        }
      }
    }
