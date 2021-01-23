    var files = Directory.GetFiles(sourceFolder);
    if (files.Length != 0)
    {
        using (var pdoc = new PrintDocument())
        using (var pdi = new PrintDialog { Document = pdoc, UseEXDialog = true })
        {
            if (pdi.ShowDialog() == DialogResult.OK)
            {
                pdoc.PrinterSettings = pdi.PrinterSettings;
                // ************************************
                // Pay attention to the following line:
                pdoc.PrintPage += pd_PrintPage;
                // ************************************
                foreach (var file in files)
                {
                    pdoc.DocumentName = file;
                    pdoc.Print();
                }
            }
        }
    }
    // The PrintPage event is raised for each page to be printed.
    private void pd_PrintPage(object sender, PrintPageEventArgs ev)
    {
        string file = ((PrintDocument)sender).DocumentName; // Current file name 
        // Do printing of the Document
        ...
    }
