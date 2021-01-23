    // before calling this code, create an instance of MyClass and fill properties with appropriate values
    // let's assume the instance is named instanceOfMyClass
    
    var stringBuilder = new StringBuilder();
    using (TextWriter writer = new StringWriter(stringBuilder))
    {
        var serializer = new System.Xml.Serialization.XmlSerializer(e.GetType());
        serializer.Serialize(writer, instanceOfMyClass);
    }
    
    //now You can call stringBuilder.ToString() to get string with the serialized XML
