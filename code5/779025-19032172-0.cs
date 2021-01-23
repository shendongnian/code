    private int GetAlexaRank(string domain)
    {
        try
        {        
            var doc = XDocument.Load(url);
            var country = xdoc.XPathSelectElement("//COUNTRY[@RANK]");
            if (country == null)
                return 0;
            return (int)country.Attribute("RANK");
        }
        catch (Exception e)
        {
            // Log exception here!    
            return -1;
        }
    }
