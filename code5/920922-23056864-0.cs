         XmlDocument Xmlabcd= new XmlDocument();
                Xmlabcd.LoadXml(xml); //xml=your xml
                foreach (XmlNode v in Xmlabcd.ChildNodes)
                {
                    if ( v.ChildNodes.Count > 0)
                    {
						bool addedit=false;
						string DBName=string.Empty;
						string serverName=string.Empty;
                        foreach (XmlNode child in v.ChildNodes)
                        {
                            if (child.Name.Equals("addedit") )
                            {
                                addedit=child.InnerText=="true"?true:false;
                            }
							if(child.Name.Equals("Db"))
							{
							DBName=child.InnerText;
							}
							if(child.Name.Equals("server"))
							{
							serverName=child.InnerText;
							}
                        }
						
						//Code to Show Db and server or to add it to one list based on bool addedit(variable) value
                    }
				}
