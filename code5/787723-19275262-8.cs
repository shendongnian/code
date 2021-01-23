    // usage - set up report
    var report = new Report {
        Header =
        {
            Name = "My new report", 
            Date = DateTime.UtcNow
        }};
    // add lineitems to body (in real case, probably a loop)
    report.Body.LineItems.Add(new LineItem()
        {
            ItemNumber = 1,
            ItemPrice = 12.30f,
            PartDescription = "New shoes", 
            PartNumber = "SHOE123"
        });
    report.Body.LineItems.Add(new LineItem()
        {
            ItemNumber = 3, 
            ItemPrice = 2.00f, 
            PartDescription = "Old shoes", 
            PartNumber = "SHOE999"
        });
    report.Body.LineItems.Add(new LineItem()
        {
            ItemNumber = 7, 
            ItemPrice = 0.25f, 
            PartDescription = "Classic Sox", 
            PartNumber = "SOX567"
        });
    // calculate the TotalPrice per lineitem
    report.CalculateLineItemTotal();
    // summerize the lineitems values in the footer
    report.CalculateFooterTotals();
    // now apply report to your canvas surface (html etc..) 
