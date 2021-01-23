    private static void DispalyData(Report report)
    {
        // set out the basics
        Console.WriteLine("Header");
        Console.WriteLine(report.ReportUid);
        Console.WriteLine(report.Header.Date);
        Console.WriteLine(report.Header.Name);
        // now loop round the body items
        Console.WriteLine("Items");
        foreach (var lineItem in report.Body.LineItems)
        {
            Console.WriteLine("New Item---");
            Console.WriteLine(lineItem.PartDescription);
            Console.WriteLine(lineItem.Quantity);
            Console.WriteLine(lineItem.ItemPrice);
            Console.WriteLine(lineItem.PartNumber);
            Console.WriteLine(lineItem.Total);
            Console.WriteLine("End Item---");
        }
        // display footer items
        Console.WriteLine("Footer");
        Console.WriteLine(report.Footer.TotalItems);
        Console.WriteLine(report.Footer.TotalPrice);
    }
    // called in code as:
    DispalyData(report);
