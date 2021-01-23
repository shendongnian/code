    pd.PrinterSettings.PrinterName = "HP LaserJet P1005";
    pd.OriginAtMargins = true;
    PaperSize pageSize = new PaperSize();
    pageSize.RawKind = 512; //this is number of created custom size 563x1251
    Margins margins = new Margins(1, 1, 1, 1);
    pd.DefaultPageSettings.Margins = margins;
    pd.DefaultPageSettings.Landscape = true;
    pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
    pd.Print();
