    string GetHTMLOutputFromXML()
    {
        StringBuilder output = new StringBuilder();
        XmlTextReader reader = null;
        try
        {
            //Get a reader
            reader = new XmlTextReader(ConfigurationManager.AppSettings["XMLPath"] + "XMLFile.xml");
            string elementName = "";
            while (reader.Read())
            {
                //For every node
                switch (reader.NodeType)
                {
                    //If you happen upon an element mark down its name
                    case XmlNodeType.Element:
                        elementName = reader.Name;
                        output.Append(elementName + " - ");
                        break;
                    //If this is an element, use its value
                    case XmlNodeType.Text:
                        output.Append( reader.Value + "<br/>");
                        break;
                }
                //You could also use the following code to get attribute values
                //if (reader.HasAttributes)
                //    output.Append(reader.GetAttribute("attr") + "<br/>");
            }
        }
        catch (Exception ex)
        {
            output.Append("Error while reading the xml file");
        }
        finally
        {
            // Close the reader.
            reader.Close();
        }
        return output.ToString();
    }
