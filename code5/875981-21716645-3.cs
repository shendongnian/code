        using (var db = new PcisDBContext())
        {
            var retAllInvoicesList= db.invoiceTables.Select(m => new InvoiceViewModel
            {
                invoiceID = m.invoiceID,
                companyName = m.companyTable.companyName,
                currency = m.currency,
                amt = m.amt,
                startDate = m.startDate,
                endDate = m.endDate,
                billerName = m.billerTable.billerName,
                attentedName = m.attentedTable.attentedName,
                status = m.status
            });
        }
       return retAllInvoicesList;
