    var result = from invoice in db.Invoices
                 join invoicedProduct in db.Invoices_Products
                   on invoice.InvoiceId equals invoicedProduct.InvoiceId
                 select new
                 {
                     InvoiceId = invoice.InvoiceId,
                     ProductId = invoicedProduct.ProductId,
                     IsFinalized = invoicedProuct.IsFinalized
                 };
    var grpResult = from record in result
                    group record by record.ProductId into productGrp
                    select productGrp;
    foreach( var grp in grpResult )
    {
        Console.WriteLine( "ProductId: " + grp.Key.ToString( ) );
        Console.WriteLine( "TotalCount: " + grp.Count( ).ToString( ) );
        Console.WriteLine( "Finalized: " + grp.Where( item => item.IsFinalized ).Count( ).ToString( ) );
    }
