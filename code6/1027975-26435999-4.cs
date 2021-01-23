    public class ActionParameter
    {
        [XmlElement("Row")]
        public List<XmlElement> RowElements
        {
            // The `get` is purely for the serializer. No reason for you to call it.
            get { return SomeMethodToSerializeToXmlDoc(Rows).ChildNodes.OfType<XmlElement>()
                                                                       .ToList(); }
            // The `set` from the Serializer will allow your "Rows" to be Deserialized.
            set { DeserializeKeyValues(value); }
        }
        
        [XmlIgnore]
        public List<SerializableKeyValuePair<string, string>> Rows { get; set; }
        void DeserializeKeyValues(List<XmlElement> elements) 
        {
             Rows = new List<SerializableKeyValuePair<string, string>>();
             foreach(XmlElement element in elements)
             {
                 // Shouldn't your List of Rows, actually be another List of Key Values?
                 // This call won't actually work. I think you need to really
                 // loop through the children of this element as your key values.
                 Rows.Add(new SerializableKeyValuePair<string, string>(element));
             }
        }
    }
