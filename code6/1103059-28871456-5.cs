    foreach (XmlNode node in tableElements)
    {
        // DECLARE VARIABLES WHEN YOU USE THEM
        // DO NOT DECLARE THEM ALL AT THE START OF YOUR METHOD
        // http://programmers.stackexchange.com/questions/56585/where-do-you-declare-variables-the-top-of-a-method-or-when-you-need-them
        dcSearchTerm searchTermEntity = new dcSearchTerm()
        {
            ID = node.GetInt("id"),
            SearchTerm = node.GetString("Search_x0020_Term"),
            ReferrerDomain = node.GetString("Referrer_x0020_Domain"),
            Country = node.GetString("Country"),
            VisitDate = node.GetDateTime("Visit_x0020_Date"),
            VisitEntryPage = node.GetString("Visit_x0020_Entry_x0020_Page"),
            Sales = node.GetInt("Sales"),
            Visits = node.GetInt("Visits"),
            Revenue = node.GetDecimal("Revenue"),
            SaleItems = node.GetDecimal("Sale_x0020_Items")
        };
        searches.Add(searchTermEntity);
        return searches;
    }
