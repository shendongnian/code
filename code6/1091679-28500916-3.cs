     public eSearchResult SearchByURI(string keyword)
        {
            string URI = "http://eutils.ncbi.nlm.nih.gov/entrez/eutils/esearch.fcgi?db=pubmed&term=" + keyword;
            XElement xml = XElement.Load(URI);
            eSearchResult pubMedResult = xml.FromXElement<eSearchResult>();
            return pubMedResult; 
        }
