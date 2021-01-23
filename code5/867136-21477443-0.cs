    // This is your expected object which you are going to write to xml.
    var sourceObject = new SomeClassToWriteInXML();
    // Writing object to XML.
    var document = new XDocument();
    var serializer = new XMLSerializer(typeof(SomeClassToWriteInXML));
    using (var writer = document .CreateWriter())
    {
        serializer.Serialize(writer, source);
    }
    // write document to a file.
    // Now document has the XML document.
    // Need to read file you have just created. For testing sake I am reading document.
    var actual = new SomeClassToWriteInXML();
    // Deserialize xml to get actual object (which should be equal to sourceObject)
    using (var reader = document.CreateReader())
    {
        actual = (SomeClassToWriteInXML)serializer.Deserialize(reader);
    }
    
    Assert.AreEqual(expected.First(), actual.First());
