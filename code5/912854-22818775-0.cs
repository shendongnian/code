    foreach( var element in combinedPayCodeCollection )
    {
        // Create the CombinedPayCode object
        var combinedPayCode = new CombinedPayCode
        {
            Name = (string)element.Attribute("Name"),
            AmountType = (string)element.Attribute("AmountType"),
            VisibleInReport = (bool)element.Attribute("VisibleInReport"),
            MoneyCategory = (bool)element.Attribute("MoneyCategory"),
            VisibleToUser = (bool)element.Attribute("VisibleToUser"),
            CustomerId = 11,
        };
        var payCodeNodes = element.Descendants("SimpleValue");
        foreach( var selectedPayCode in payCodeNodes )
        {
            var combinedPayCodeList = new CombinedPayCodeList
            {
                PayCodeId = selectedPayCode.FirstAttribute.Value,
            };
            // Add each PayCodeNode to the CombinedPayCode
            combinedPayCode.CombinedPayCodeLists.Add( combinedPayCodeList );
        }
        // Add the CombinedPayCode (which includes all the PayCodeNodes) to
        // the object context and save the whole shebang.
        _db.CombinedPayCodes.Add(combinedPayCode);
        _db.SaveChanges();
