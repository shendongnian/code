                        XmlNode node = xmlReader.DocumentElement.FirstChild;
                        XmlNodeList lstPackage = node.ChildNodes;
                        for (int i = 0; i < 2; i++)
                        {
                            //MessageBox.Show(lstPackage[i].Name.ToString());
                            if (lstPackage[i].Name == "AR-PACKAGE")
                            {
                                aux++;
                            }
                            if(aux==2)
                            {
                                aux = 0;
                                XmlNodeList lstShortname = lstPackage[i].FirstChild.ChildNodes;
                                // Display the value of its first child node
                                for (int j = 0; j < lstShortname.Count; j++)
                                    MessageBox.Show(lstShortname[j].InnerText);
                            }
                        }
