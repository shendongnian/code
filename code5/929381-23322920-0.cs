    IEnumerable<XElement> InvoiceLines = 
            from e in Document.Root
                              .Element(P + "InvoiceLines")
                              .Elements(P + "InvoiceLine")
            select new XElement("InvoiceLine",
                     new XAttribute("LineNumber", (string)e.Element(P + "ID") ?? ""),
                     new XAttribute("ProductName", (string)e.Element(P + "Item").Attribute(P + "Description") ?? ""),
                     new XAttribute("UnitPriceTaxInclusive", (string)e.Element(P + "UnitPriceTaxInclusive") ?? ""),
                     new XAttribute("Quantity", (string)e.Element(P + "InvoicedQuantity") ?? ""),
                     new XAttribute("UnitCode", (string)e.Element(P + "InvoicedQuantity").Attribute(P + "@unitCode") ?? ""));  
