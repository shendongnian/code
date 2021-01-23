    switch (r.NodeType) {
                                case XmlNodeType.Element:
                                    if (r.Name.Equals("a"))
                                    {
                                        string x = await r.ReadInnerXmlAsync();
                                        OnReceive(x);
                                    }                               
                                    break;
                            }
