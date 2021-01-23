    [serializable]
    public class Data
    {
        [XmlIgnore]
        Public XmlNode VariableXMLData {get; set;}
        
        [XmlElement(ElementName="VariableXMLData")]
        Public XmlNode VariableXMLDataParts {
          get{
             //handle the deserialization => returning the nodes you wich to return
             // example only return the roots descendants...
          }
          set{
               // handle your serialization if needed
          }
    }
