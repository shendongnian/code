    public List<XAttribute> ElementAttributes = new List<XAttribute>();
        foreach (XAttribute attr in xElement.Attributes())
                    {
                        ElementAttributes.Add(attr);
                    }
    
    List<XAttribute> otherAttributes = other.ElementAttributes;
                    foreach (XAttribute attr in ElementAttributes)
                    {
                        XAttribute otherAttribute = otherAttributes.FirstOrDefault(x => x.Name == attr.Name);
    
                        if (otherAttribute == null)
                        {
                            //--Your error handling logic here
                            
                            flag = false;
                        }
    
                        else
                        {
                            if (otherAttribute.Value != attr.Value)
                            {
                                //--Your error handling logic here
                                
                                flag = false;
                            }
                        }
                    }
