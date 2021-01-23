      public class CustomConfigurationSectionHandler : IConfigurationSectionHandler { 
         public object Create(object parent, 
           object configContext, System.Xml.XmlNode section)
               {
                     //check if section is a line , if yes return null
                     if( section ...)
                     { return null; }
                     //otherwise return whatever result you want :)
                     else {  }
               }
       }
