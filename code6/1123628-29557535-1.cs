      private readonly Dictionary<string, object> dictionary = new Dictionary<string, object>();
...
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToElement();
            string type = null;
            string name = null;
            object result = null;
            while (reader.Read())
            {
                
                if ((reader.NodeType == XmlNodeType.Element))
                {
                    type = reader.GetAttribute("xsi:type");
                    name = reader.Name; 
                }
                if ((reader.NodeType == XmlNodeType.Text))
                {
                    if (type != null)
                    {
                        switch (type.ToLower())
                        {
                            case "xsd:int":
                                result = reader.ReadContentAsInt();
                                break;
                            case "xsd:double":
                                result = reader.ReadContentAsDouble();
                                break;
                            case "xsd:float":
                                result = reader.ReadContentAsFloat();
                                break;
                            case "xsd:string":
                                result = reader.ReadContentAsString();
                                break;
                            case "xsd:datetime":
                                result = reader.ReadContentAsDateTime();
                                break;
                            case "xsd:boolean":
                                result = reader.ReadContentAsBoolean();
                                break;
                            default:
                                result = reader.ReadContentAsString();
                                break;
                        }
                        dictionary.Add(name, result);
                    }               
                }
                if ((reader.NodeType == XmlNodeType.EndElement))
                {
                    if(reader.Name =="AdditionalValues")
                    {
    //Edit - add read before break or deserialisation will end here.
    reader.Read();
                        break;
                    }
                }
            }
        }
