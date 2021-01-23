    public class PropertiesMapping{
      [XmleElement]
      public string WEB_Class {get;set;}
      [XmleElement]
      public string COM_Class{get;set;}
    
      [XmlArray("Mappings")]
      public Map[] Mappings {get;set;}
    }
    
    public class Map{
      [XmleElement]
      public string WEB_Property{get;set;}
      [XmleElement]
      public string COM_Property{get;set;}
    }
 
