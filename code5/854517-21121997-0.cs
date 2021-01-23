    try
    {
        int[] numbers = new int[2];
        numbers[6] = 345;
    }
    catch (Exception ex)
    {
          Type t = ex.GetType();
          var props = t.GetProperties();
          foreach (var p in props)
          {
              Console.WriteLine(p.Name + " : " + p.GetValue(ex));
          }
    }
