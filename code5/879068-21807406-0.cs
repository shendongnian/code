    var source = data.GroupBy(i => new { i.ID, i.InvoiceNumber })
               .Select(g => new MyData
               {
                   ID = g.First().ID,
                   InvoiceNumber = g.Key.InvoiceNumber,
                   DeliveryNoteNumber = string.Join(", ", g.Select(i => i.DeliveryNoteNumber).Distinct()),
                   QuotationNumber = string.Join(", ", g.Select(i => i.QuotationNumber).Distinct()),
               });
