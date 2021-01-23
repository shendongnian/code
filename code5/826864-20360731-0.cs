    public class XmlImmutableAttribute : XmlSerializedAttribute
    {
        
      private static readonly object _syncroot       = new object() ;
      private static HashSet<Type>   _immutableTypes = null ; 
      private static HashSet<Type> ImmutableTypes
      {
        get
        {
          lock ( _syncroot )
          {
            if ( _immutableTypes == null )
            {
              _immutableTypes = new HashSet<Type>(
                                  AppDomain
                                  .CurrentDomain
                                  .GetAssemblies()
                                  .SelectMany( a => a.GetTypes() )
                                  .Where( t => t.IsDefined( typeof(XmlImmutableAttribute) , true ) )
                                  ) ;
            }
          }
          return _immutableTypes ;
        }
      }
        
      public static bool IsAttachedTo( Type type )
      {
        bool isImmutable = ImmutableTypes.Contains(type) ;
        return isImmutable ;
      }
        
      public static bool IsAttachedTo<T>()
      { // returns true if the attached type is marked immutable
        return IsAttachedTo( typeof( T ) );
      }
        
    }
