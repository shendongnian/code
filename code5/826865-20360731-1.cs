    public class XmlImmutableAttribute : XmlSerializedAttribute
    {
          
      private static readonly Dictionary<Type,bool> ImmutableTypes = new Dictionary<Type,bool>() ;
      
      public static bool IsAttachedTo( Type type )
      {
        if ( type == null ) throw new ArgumentNullException("type");
        bool isImmutable ;
        lock ( ImmutableTypes )
        {
          bool found = ImmutableTypes.TryGetValue(type, out isImmutable ) ;
          if ( !found )
          {
            isImmutable = type.IsDefined(typeof(XmlImmutableAttribute),true) ;
            ImmutableTypes.Add(type,isImmutable) ;
          }
        }
        return isImmutable ;
      }
      
      public static bool IsAttachedTo<T>()
      { // returns true if the attached type is marked immutable
        return IsAttachedTo( typeof(T) );
      }
      
    }
