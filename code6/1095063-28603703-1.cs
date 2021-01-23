    Document ResultPDF = new Document(iTextSharp.text.PageSize.A4, 25, 10, 20, 30);
            Write.PageEvent = new MyPdfPageEventHelpPageNo();
    //Those below can improve the layout and functions of the pdf you create
            PdfPTable Headtable = new PdfPTable(7);
            Headtable.TotalWidth = 525f;
            Headtable.LockedWidth = true;
            Headtable.HeaderRows = 5;
            Headtable.FooterRows = 2;
            Headtable.KeepTogether = true;
            Headtable.SetExtendLastRow(false, true);
