      // property as a whole is "public", but "set" accessor is "private"
      // and so the accessor is more restrictive than the property
      public OdbcConnection db { // <- property as whole is "public"
        get; 
        private set; // <- accessor is "private" (more restrictive than "public")
      }
