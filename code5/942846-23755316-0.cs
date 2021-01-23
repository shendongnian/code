    private string GetGroup(string xml, string id) 
        {
            XDocument document;
            XElement element;
            try
            {
                document = XDocument.Load(xml);
                //element = document.Root.Elements("Permissiongroup").FirstOrDefault(e => e.Attribute("id").Value == id);
                element = document.Elements("Permissiongroup").FirstOrDefault(e => e.Attribute("id").Value == id);
                if (element != null)
                {
                    return element.Attribute("display").Value;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally 
            {
                document = null;
                element = null;
            }
        }
