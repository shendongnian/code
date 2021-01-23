    public static String PrintXML(String XML)
    {
        String result = "";
        string[] xmlSeperators = new string[] { "<?" };
        string[] splitResults = new string[2];
    
        if (!String.IsNullOrEmpty(XML))
        {
            MemoryStream mStream  = null;
            try
            {
                mStream = new MemoryStream();
                using (XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode))
                {
                    XmlDocument document = new XmlDocument();
                    try
                    {
                        // Load the XmlDocument with the XML.
                        //Check if it is only XML 
                        if (XML.StartsWith("<?"))
                        {
                            document.LoadXml(XML);
                        }
                        else
                        {
                            //Split the string appended before XML
                            splitResults = XML.Split(xmlSeperators, 2, StringSplitOptions.None);
                            if (splitResults.Length > 1)
                            {
                                string d = "<?" + splitResults[1];
                                document.LoadXml(d);
                            }
                        }
                        writer.Formatting = System.Xml.Formatting.Indented;
                        // Write the XML into a formatting XmlTextWriter
                        document.WriteContentTo(writer);
                        //xx.WriteTo(writer);
                        writer.Flush();
                        mStream.Flush();
                        // Have to rewind the MemoryStream in order to read its contents.
                        mStream.Position = 0;
                        // Read MemoryStream contents into a StreamReader.
                        StreamReader sReader = new StreamReader(mStream);
                        // Extract the text from the StreamReader.
                        String FormattedXML = sReader.ReadToEnd();
    
                        if (splitResults[0] != null)
                        {
                            result = splitResults[0] + "\n" + FormattedXML;
                        }
                        else
                        {
                            result = FormattedXML;
                        }
                    }
                    catch (XmlException xe)
                    {
                        Log.Error(xe);
                        throw;
                    }
                }
            }
            finally 
            {
    
                if (mStream != null)
                {
                    mStream.Dispose();
                }
    
            }
        }
        return result;
    }
