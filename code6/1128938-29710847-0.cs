    public static void Main(string[] args)
    {
      var a = new A()
      {
        X1 = 1,
        X2 = "2",
        X3 = new List<B> { new B { Y1 = 5, Y2 = 7 } }
      };
      PrintProperties(a);
    }
    private static void PrintProperties(object obj)
    {
      foreach (var prop in obj.GetType().GetProperties())
      {
        var propertyType = prop.PropertyType;
        var value = prop.GetValue(obj);
        Console.WriteLine("{0} = {1} [{2}]", prop.Name, value, propertyType);
        if (typeof(IList).IsAssignableFrom(propertyType))
        {
          var list = (IList)value;
          foreach (var entry in list)
          {
            PrintProperties(entry);
          }
        }
        else
        {
          if (prop.PropertyType.Namespace != "System")
          {
            PrintProperties(value);
          }
        }
      }
    }
