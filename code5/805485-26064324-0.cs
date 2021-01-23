    using System.Reflection;
    
    
    public static class Generics {
     public static void T0<T> ( T obj ) where T : new () {
      Console.WriteLine ( "{0} {1}", obj, obj.GetType () );
     }
    
     public static void T1<T> ( T obj ) {
      MethodInfo mi = GenericMethodInfo ( typeof ( Generics ), "T0", typeof ( T ) );
      mi.Invoke ( null, new object[] { obj } );
     }
    
     public static MethodInfo GenericMethodInfo ( Type classType, string methodName, Type genericType ) {
      return classType.GetMethod ( methodName ).MakeGenericMethod ( genericType );
     }
    }
    
    
    Generics.T0 ( 123 );
    Generics.T1 ( 123 );
    // Impossible.. Generics.T0 ( "12345" );
    Generics.T1 ( "12345" );
