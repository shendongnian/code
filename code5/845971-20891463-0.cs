      public static class TypeExtension
        {
            public static IEnumerable<Type> GetInterfaces(this Type type)
            {
                foreach (var intf in type.GetInterfaces())
                {
                    yield return intf;
    
                    foreach (var x in intf.GetInterfaces())
                        yield return x;
                }
            }
        }  
      
