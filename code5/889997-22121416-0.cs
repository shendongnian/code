       public static void SaveListOfT_ToFile< T >( List< T > l, string filename )
       {
          Type[] extraTypes = new Type[1];
          extraTypes[ 0 ] = typeof ( T );
    
          XmlSerializer xs = new XmlSerializer( typeof ( List< T > ), extraTypes );
    
          using ( StreamWriter writer = new StreamWriter( filename ) )
          {
             xs.Serialize( writer, l );
          }
       }
    
       public static List< T > LoadListOfT_FromFile< T >( string filename )
       {
          try
          {
             Type[] extraTypes = new Type[1];
             extraTypes[ 0 ] = typeof ( T );
    
             XmlSerializer xs = new XmlSerializer( typeof ( List< T > ), extraTypes );
             List< T > a;
    
             using ( FileStream f = new FileStream( filename, FileMode.Open ) )
             {
                // Use the Deserialize method to restore the object's state with
                // data from the XML document. 
                a = ( List< T > )xs.Deserialize( f );
             }
    
    
             return a;
          }
          catch ( Exception )
          {
             return null;
          }
       }
