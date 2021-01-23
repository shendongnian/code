    using System;
    using System.Xml;
    
    public class Sample {
    
      public static void Main() {
    
        // Create the XmlDocument.
        XmlDocument doc = new XmlDocument();
        doc.LoadXml("<item><name>wrench</name></item>");
   
        using (var stringWriter = new StringWriter())
          using (var xmlTextWriter = XmlWriter.Create(stringWriter))
          {
            xmlDoc.WriteTo(xmlTextWriter);
            xmlTextWriter.Flush();
            string s = stringWriter.GetStringBuilder().ToString();
          }
        }
    }
