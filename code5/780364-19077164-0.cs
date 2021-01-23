    public YourFormConstructor( string[] someParmArray )
    {
       if( someParmArray.Length == 0 )
          form.SomeProperty = string.Empty;
       else
       {
          foreach( string s in someParmArray )
          {
             // do something based on each string "s" provided..
             if( s.StartsWith( "-aCommandLineArgumentFlag1" ))
               blah...
    
             if( s.StartsWith( "-aDiffCommandLineArgumentFlag" ))
               blah...
          }
       }
    }
