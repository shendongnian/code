    var invoiceGroups = from r1 in Table1.AsEnumerable()
                        join r2 in Table2.AsEnumerable()
                        on r1.Field<int>("InvoiceNo") equals r2.Field<int>("InvoiceNo")
                        group r2 by r2.Field<int>("InvoiceNo") into InvoiceGroup
                        select InvoiceGroup;
    Dictionary<int, int> invoiceSumLookup = invoiceGroups
        .ToDictionary(ig => ig.Key, ig => ig.Sum(r => r.Field<int>("Amount")));
    foreach(DataRow row in Table1.Rows)
        row.SetField("PaidAmount", invoiceSumLookup[row.Field<int>("InvoiceNo")]);
