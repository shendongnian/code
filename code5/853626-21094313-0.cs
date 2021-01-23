    invoices.GroupBy(i => new {i.Address, i.Reference1})
            .Select(g => new InvoiceRO {
                            ID              = g.First().ID, 
                            Address         = g.Key.Address, 
                            Reference1      = g.Key.Reference1,
                            DNNumber        = string.Join(", ", g.Select(i => i.DNNumber)),
                            QuotationNumber = string.Join(", ", g.Select(i => i.QuotationNumber))
                            }
