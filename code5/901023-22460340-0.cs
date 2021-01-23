       PrintKeysAndValues(Request.Form);
       PrintKeysAndValues(Request.Request);
  
       public static void PrintKeysAndValues( NameValueCollection myCol )  {
          Console.WriteLine( "   KEY        VALUE" );
          foreach ( String s in myCol.AllKeys )
             Console.WriteLine( "   {0,-10} {1}", s, myCol[s] );
          Console.WriteLine();
       }
