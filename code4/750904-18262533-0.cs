    static bool IsInstanceOfGenericType( object o, Type genericType )
    {
        bool isGenericTypeInstance = false ;
        for ( Type t = o.GetType() ; t != null && !isGenericTypeInstance ; t = t.BaseType )
        {
          isGenericTypeInstance =  t.IsGenericType
                                && t.GetGenericTypeDefinition() == genericType
                                ;
        }
        return isGenericType ;
    }
