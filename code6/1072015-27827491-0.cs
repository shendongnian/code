       private void button42_Click(object sender, EventArgs e)
       {
           ArrayList arrList = 
        FetchSiteQuery("http://localhost:21608/api/sitequery/getall/dbill/ppus/42"); 
            String omnivore = "<SiteQueries>";
            foreach (String s in arrList) //- see siteQueryData.png
            {
                omnivore += s;
            }
            omnivore += "</SiteQueries>";
    
            String messedUpJunk = "<ArrayOfSiteQuery xmlns:i=\"http://www.w3.org/2001/XMLSchema-
        instance\" xmlns=\"http://schemas.datacontract.org/2004/07/CStore.DomainModels.HHS\">";
            omnivore = omnivore.Replace(messedUpJunk, String.Empty);
            omnivore = omnivore.Replace("</ArrayOfSiteQuery>", String.Empty);
    
            XDocument xmlDoc = XDocument.Parse(omnivore);
            List<SiteQuery> sitequeries = 
        xmlDoc.Descendants("SiteQuery").Select(GetSiteQueryForXMLElement).ToList();
        }
    
        private static SiteQuery GetSiteQueryForXMLElement(XElement sitequery)
        {
            return new SiteQuery
            {
                Id = sitequery.Element("Id").Value,
                UPCPackSize = Convert.ToInt32(sitequery.Element("UPCPackSize").Value),
                UPC_Code = sitequery.Element("UPC_Code").Value,
                crvId = sitequery.Element("crvId").Value,
                dept = Convert.ToInt32(sitequery.Element("dept").Value),
                description = sitequery.Element("description").Value,
                openQty = Convert.ToDouble(sitequery.Element("openQty").Value),
                packSize = Convert.ToInt32(sitequery.Element("packSize").Value),
                subDept = Convert.ToInt32(sitequery.Element("subDept").Value),
                unitCost = Convert.ToDecimal(sitequery.Element("unitCost").Value),
                unitList = Convert.ToDecimal(sitequery.Element("unitList").Value),
                vendorId = sitequery.Element("vendorId").Value,
                vendorItem = sitequery.Element("vendorItem").Value,
            };
        }
