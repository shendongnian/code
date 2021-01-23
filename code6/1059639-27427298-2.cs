    namespace XMLSerializationDemo
    {
        public static class RUBIObjectSerialization
        {
            public static string SerializeToXML(this RUBIObjectCollection source)
            {
                //Create a string writer in order to output to console as opposed to file
                using (var sw = new StringWriter())
                {
                    //Settings to configure the way the XML will be output to the console. Really, only Indent = true; is needed.
                    var settings = new XmlWriterSettings();
                    settings.NewLineChars = Environment.NewLine;
                    settings.IndentChars = "  ";
                    settings.NewLineHandling = NewLineHandling.Replace;
                    settings.Indent = true;
    
                    //Create writer that writes the xml to the string writer object
                    using (var xw = XmlWriter.Create(sw, settings))
                    {
                        //Create serializer that can serialize a collection of RUBIObjects
                        XmlSerializer serializer =
                            new XmlSerializer(typeof(RUBIObjectCollection));
    
                        //Serialize this instance of a RUBICollection object, into XML and write to the string writer output
                        serializer.Serialize(xw, source);
    
                        //Flush the xmlwriter stream as it isn't needed any longer
                        xw.Flush();
                    }
    
                    //Return the XML as a formatted string
                    return sw.ToString();
                }
            }
    
            public static RUBIObjectCollection DeserializeToCollection(this string source)
            {
                RUBIObjectCollection collection = null;
                XmlSerializer serializer = null;
    
                //Read the XML string into a stream.
                using (var sr = new StringReader(source))
                {
                    //Instantiate an XML Serializer to expect a collection of RUBI Objects
                    serializer = new XmlSerializer(typeof(RUBIObjectCollection));
    
                    //Deserialize the XML stream to a collection
                    collection = (RUBIObjectCollection)serializer.Deserialize(sr);
                }
    
                return collection;
            }
        }
    }
