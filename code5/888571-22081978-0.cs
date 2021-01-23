    public static IEnumerable<Attribute>  AllAttributes( PropertyInfo pi )
    {
      if ( pi != null )
      {
        // enumerate all the attributes on this property
        foreach ( object o in pi.GetCustomAttributes( false ) )
        {
          yield return (Attribute) o ;
        }
        
        PropertyInfo parentProperty = FindNearestAncestorProperty(pi) ;
        foreach( Attribute attr in AllAttributesRecursive(parentProperty) )
        {
          yield return attr ;
        }
        
      }
      
    }
    
    private static PropertyInfo FindNearestAncestorProperty( PropertyInfo property )
    {
      if ( property == null ) throw new ArgumentNullException("property") ;
      if ( property.DeclaringType == null ) throw new InvalidOperationException("all properties must belong to a type");
      
      // get the property's nearest "ancestor" property
      const BindingFlags flags = BindingFlags.DeclaredOnly
                               | BindingFlags.Public | BindingFlags.NonPublic
                               | BindingFlags.Static | BindingFlags.Instance
                               ;
      Type         t        = property.DeclaringType.BaseType ;
      PropertyInfo ancestor = null ;
      
      while ( t != null && ancestor == null )
      {
        ancestor = t.GetProperty(property.Name,flags) ;
        t        = t.BaseType ;
      } ;
      
      return ancestor ;
    }
