    PrintCapabilities printCapabilities = queue.GetPrintCapabilities();
    PageMediaSize pageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA4);
    if (printCapabilities.PageMediaSizeCapability.Contains(pageMediaSize))
    {
    PrintTicket deltaPrintTicket = new PrintTicket {PageMediaSize = pageMediaSize };
        
    var result = queue.MergeAndValidatePrintTicket(queue.UserPrintTicket,deltaPrintTicket);
        
    if (result.ValidatedPrintTicket.PageMediaSize == pageMediaSize)
    {
    queue.UserPrintTicket = result.ValidatedPrintTicket;
    queue.Commit();
    }
    }
