                XmlDocument doc = new XmlDocument();
                doc.Load(AppDomain.CurrentDomain.BaseDirectory + "Settings.xml");
                XmlElement root = doc.DocumentElement;
                string contents = "";
                try
                {                    
                    foreach (XmlNode node in root.SelectNodes(path))
                    {                        
                        XmlNode child = node.SelectSingleNode(read);
                        if (child != null)
                        {                            
                            contents = child.InnerText;
                            return contents;
                        }
                        return contents;
                    }
                    return contents;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
