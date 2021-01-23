        XmlDocument xmlDoc = null;
        try
        {
            xmlDoc = DocumentLoad(filepath);
        }
        catch (XmlException)
        {
        }
        if( xmlDoc == null ){
            try
            {
                xmlDoc = DocumentLoadXml(filepath);
            }
            catch (Exception)
            {                    
                throw;
            }
        }
