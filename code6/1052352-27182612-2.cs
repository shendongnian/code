                   XmlNodeList references = doc.ChildNodes[1].SelectNodes("//ms:ItemGroup/ms:Reference", ns);
                    foreach (XmlNode node in references)
                    {
                        string name_space = node.Attributes["Include"].InnerText;
                        string name_space_path;
                        XmlNode nHintPath = node.SelectSingleNode("//ms:HintPath", ns);
                        if (nHintPath != null)
                        {
                            name_space_path = nHintPath.InnerText;
                            if (!Path.IsPathRooted(name_space_path))
                            {
                                name_space_path = Path.Combine(project_path, name_space_path);
                            }
                        }
                    }
