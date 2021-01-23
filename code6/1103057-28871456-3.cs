        foreach (XmlNode node in tableElements)
    {
        dcSearchTerm searchTermEntity = new dcSearchTerm();
        // DECLARE VARIABLES WHEN YOU USE THEM
        // DO NOT DECLARE THEM ALL AT THE START OF YOUR METHOD
        // http://programmers.stackexchange.com/questions/56585/where-do-you-declare-variables-the-top-of-a-method-or-when-you-need-them
        // assigning reference values to the entity
        searchTermEntity.ID = node.GetInt("id");
        searchTermEntity.SearchTerm = node.GetString("Search_x0020_Term");
        searchTermEntity.ReferrerDomain = node.GetString("Referrer_x0020_Domain");
        searchTermEntity.Country = node.GetString("Country");
        searchTermEntity.VisitDate = node.GetDateTime("Visit_x0020_Date");
        searchTermEntity.VisitEntryPage = node.GetString("Visit_x0020_Entry_x0020_Page");
        searchTermEntity.Sales = node.GetInt("Sales");
        searchTermEntity.Visits = node.GetInt("Visits");
        searchTermEntity.Revenue = node.GetDecimal("Revenue");
        searchTermEntity.SaleItems = node.GetDecimal("Sale_x0020_Items");
        searches.Add(searchTermEntity);
        return searches;
    }
