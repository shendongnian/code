    ObjectCreationHandling och = ObjectCreationHandling.Auto;
    if( typeInitializer == null )
    {
     if( parameterlessConstructor )
     {
      och = ObjectCreationHandling.Reuse;
     }
     else
     {
      och = ObjectCreationHandling.Replace;
     }
    }
