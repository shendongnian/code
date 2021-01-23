    private void BuildInvoiceEntity(Intuit.Ipp.Data.Invoice qboInvoice, Entities.Invoice invoice)
    {
        ...
        // Get the Id value of the item by name
        string itemTypeId = _Items.Where(o => o.Name == line.ItemName).FirstOrDefault().Id;
    
        // Specify the Id value in the item reference of the SalesItemLineDetail
        var qboInvoiceLine = new Intuit.Ipp.Data.Line()
        {
            Amount = (decimal)amount,
            AmountSpecified = true,
            Description = line.Description,
            DetailType = LineDetailTypeEnum.SalesItemLineDetail,
            DetailTypeSpecified = true,
            AnyIntuitObject = new SalesItemLineDetail()
            {
                ItemRef = new ReferenceType() { Value = itemTypeId },
                AnyIntuitObject = (decimal)line.Rate,
                ItemElementName = ItemChoiceType.UnitPrice
            }
        };
        ...
    }
