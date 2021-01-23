    // Get the Id value of the item by name
    string itemTypeId = _Items.Where(o => o.Name == line.ItemName).FirstOrDefault().Id;
    
    // Specify the Id value in the item reference of the SalesItemLineDetail
    AnyIntuitObject = new SalesItemLineDetail()
    {
        ItemRef = new ReferenceType() { Value = itemTypeId },
        AnyIntuitObject = (decimal)line.Rate,
        ItemElementName = ItemChoiceType.UnitPrice
    }
