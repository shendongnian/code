    public void ExtractUsingReflection<T>(IEnumerable<T> list)
    {
      var names = list.Select(o => new
                                   {
                                     Name = GetStringValue(o, "Name"),
                                     Surname = GetStringValue(o, "Surname")
                                   });
      foreach (var n in names)
      {
        Console.WriteLine(n.Name + " " + n.Surname);
      }
    }
    private static string GetStringValue<T>(T obj, string propName)
    {
      return obj.GetType().GetProperty(propName).GetValue(obj, null) as string;
    }
