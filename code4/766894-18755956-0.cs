    private static bool IsHubType(Type type)
        {
          try
          {
            return typeof (IHub).IsAssignableFrom(type) && !type.IsAbstract 
                     && (type.Attributes.HasFlag((Enum) TypeAttributes.Public) 
                     || type.Attributes.HasFlag((Enum) TypeAttributes.NestedPublic));
          }
          catch
          {
            return false;
          }
        }
