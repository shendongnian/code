    static Dictionary<string, string> TypeMap = new Dictionary<string, string>() {
      { "System.String", "xs:string" },
      { "System.Int32", "xs:int" },
      . . . 
    };
    . . . 
      string schemaTypeName;
      if (TypeMap.TryGetValue(barProperty.PropertyType.FullName, out schemaTypeName)) {
        barElement.SchemaTypeName = new QualifiedName("xs:string");
      } else {
        //do other stuff with types that are not default types
      }
