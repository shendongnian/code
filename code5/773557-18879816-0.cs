    [XmlRoot( "model" )]
    public class CommandModel
    {
      [XmlAttribute( "name" )]
      public string Name { get; set; }
      
      [XmlAttribute( "AllObjects" )]
      public bool AllObjects { get; set; }
      
      [XmlElement( "objectType" )]
      public List<ObjectType> ObjectTypes { get; set; }
      
    }
    [XmlRoot( "objectType" )]
    public class ObjectType
    {
      [XmlAttribute( "name" )]
      public string Name { get; set; }
      
      [XmlAttribute( "allproperties" )]
      public bool AllProperties { get; set; }
      
      [XmlElement( "IncludeProperty" )]
      public List<Property> IncludedProperties { get; set; }
      
    }
    
    [XmlRoot( "IncludeProperty" )]
    public class Property
    {
      
      [XmlAttribute( "name" )]
      public string Name { get; set; }
      
    }
