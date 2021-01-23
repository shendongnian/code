    public void ExtractUsingInterface<T>(IEnumerable<T> list) where T : INamable
    {
      var names = list.Select(o => new { Name = o.Name, Surname = o.Surname });
      
      foreach (var n in names)
      {
        Console.WriteLine(n.Name + " " + n.Surname);
      }
    }
