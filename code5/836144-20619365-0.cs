    public class MyXmlTextWriter : XmlTextWriter
    {
      public MyXmlTextWriter(TextWriter writer) : base(writer) { }
      
      public override void WriteEndElement()
      {
        base.WriteFullEndElement();
      }
    
      // Override any additional XML serialization methods.
    }
