    //This line works
    Document pdfdoc = new Document(PageSize.A4);
    //===================================================================================
         //I make the mistake, and declare the 
         Document pdfdoc;
         //global as 
         private static Document pdfdoc;
         // and this one works only for one creating PDF not for several at the same time.
    //===================================================================================
    PdfWriter writer;
    string Pfad = @"\...." + Filename; //Filename is with a random number.
    writer = PdfWriter.GetInstance(pdfdoc, new FileStream(Server.MapPath(Pfad), 
    writer.ViewerPreferences = PdfWriter.PageModeUseOutlines;
    TwoColumnHeaderFooter eventHandler = new TwoColumnHeaderFooter();
    writer.PageEvent = eventHandler;
    pdfdoc.Open();
