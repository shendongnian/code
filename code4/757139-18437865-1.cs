    XmlNode rootNode = xDoc.SelectSingleNode("RunResult");
                                if (rootNode.HasChildNodes)
                                {
                                    foreach (XmlNode node in rootNode.ChildNodes)
                                    {
                                        if (node.Name =="RecordsProcessed")
                                        {
                                            NofRecords=Convert.ToInt32(node.InnerText);
                                        }
                                    }
                                }
