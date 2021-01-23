        myXmlTextWriter = new XmlTextWriter(fs,Encoding.ASCII);
        myXmlTextWriter.Formatting = Formatting.Indented;
        myXmlTextWriter.WriteStartDocument(false);
        myXmlTextWriter.WriteComment("World Map ID:");
        //World and his attribute
        myXmlTextWriter.WriteStartElement("World");
        myXmlTextWriter.WriteStartElement("Matrix", null);
        myXmlTextWriter.WriteStartElement("Regions");
}
    }
