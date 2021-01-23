    // Load pdf files from a folder
    string folderPath = @"E:\Loans\cirruslsdemo\HICODistributing";
    string[] files = Directory.GetFiles(folderPath, "*.pdf");
    // Print pdf files one by one
    foreach (string pdfFile in files)
    {
        printDocument(pdfFile);
    }
    private void printDocument(string pdfFile)
    {
        PdfViewer viewer = new PdfViewer();
        viewer.BindPdf(pdfFile);
        System.Drawing.Printing.PrinterSettings printersetting = new System.Drawing.Printing.PrinterSettings();
        printersetting.Copies = 1; //specify number of copies
        printersetting.PrinterName = "Conan-printer"; // name of default printer to be used
        System.Drawing.Printing.PageSettings pagesetting = new System.Drawing.Printing.PageSettings();
        pagesetting.PaperSource = printersetting.PaperSources[1]; //assign paper source to pagesettings object
        //you can either specify the index of the tray or you can loop through the trays as well.
        viewer.PrintDocumentWithSettings(pagesetting, printersetting);
        viewer.Close();
    }
