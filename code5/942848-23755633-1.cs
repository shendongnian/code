    // string group = GetGroup(xmlpath, "Hessen"); // returns KV-IT
    // string group2 = GetGroup(xmlpath, "Berlin"); //DBG_Update
    private string GetGroup(string xml, string id)
    {
        XDocument document;
        XElement element;
        try
        {
            document = XDocument.Load(xml);
            
            element = document.Elements("Permissiongroup").Elements(("Permission")).FirstOrDefault(t => t.Attribute("id").Value == id);
            if (element != null)
            {
                return element.Attribute("display").Value;
            }
            else
            {
                return string.Empty;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
        finally
        {
            document = null;
            element = null;
        }
    }
