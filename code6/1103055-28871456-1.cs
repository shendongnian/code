    foreach (XmlNode node in tableElements)
    {
        dcSearchTerm searchTermEntity = new dcSearchTerm();
        // DECLARE VARIABLES WHEN YOU USE THEM
        // DO NOT DECLARE THEM ALL AT THE START OF YOUR METHOD
        // assigning reference values to the entity
        searchTermEntity.ID = node["id"].InnerText.ToInt32();
        searchTermEntity.SearchTerm = node["Search_x0020_Term"].InnerText;
        searchTermEntity.ReferrerDomain = node["Referrer_x0020_Domain"].InnerText;
        searchTermEntity.Country = node["Country"].ValueOrEmpty();
        searchTermEntity.VisitDate = node["Visit_x0020_Date"].InnerText.ToDateTime();
        searchTermEntity.VisitEntryPage = node["Visit_x0020_Entry_x0020_Page"].InnerText;
        searchTermEntity.Sales = node["Sales"].InnerText.ToInt32();
        searchTermEntity.Visits = node["Visits"].InnerText.ToInt32();
        searchTermEntity.Revenue = node["Revenue"].InnerText.ToDecimal();
        searchTermEntity.SaleItems = node["Sale_x0020_Items"].InnerText.ToDecimal();
        searches.Add(searchTermEntity);
        return searches;
    }
