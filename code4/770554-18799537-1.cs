        foreach (XmlElement xmlElement in nodeList)
                {
                    foreach (XmlElement xmlElement1 in xmlElement.ChildNodes)
                    {
                        foreach (XmlElement xmlElement2 in xmlElement1.ChildNodes)
                        {
                            string value = xmlElement2.InnerText;
                            Debug.WriteLine(value);
                        }
                    }
                }
