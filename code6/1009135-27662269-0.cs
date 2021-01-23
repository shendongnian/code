    var sizeOfPage = GetPageSizeToPrint(Globals.LayoutSettings.paperSize.ToUpper());
    foreach(var page in doc.Pages)
    {
        page.Child.Height = sizeOfPage.Height;
        page.Child.Width = sizeOfPage.Width;
    }
    pd.PrintDocument(doc.DocumentPaginator, "TempLabel_" + DateTime.Now.Ticks.ToString());
