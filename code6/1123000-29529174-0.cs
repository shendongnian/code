    using System.Reflection;
    
    public class Test
    {
      public string Name { get; set; }
      public int Id { get; set; }
    }
    
    void DoClone()
    {
      var o = new Test { Name = "Fred", Id = 42 };
    
      Type t = o.GetType();
      var properties = t.GetTypeInfo().DeclaredProperties;
      var p = t.GetTypeInfo().DeclaredConstructors.FirstOrDefault().Invoke(null);
    
      foreach (PropertyInfo pi in properties)
      {
        if (pi.CanWrite)
          pi.SetValue(p, pi.GetValue(o, null), null);
      }
    
      dynamic x = p;
      // Important: Can't use dynamic objects inside WriteLine call
      // So have to create temporary string
      String s = x.Name + ": " + x.Id;
      Debug.WriteLine(s);
    }
