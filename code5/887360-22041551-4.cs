    var files = Directory.GetFiles(sourceFolder);
    if (files.Length != 0)
    {
        using (var pdi = new PrintDialog { Document = new PrintDocument(), UseEXDialog = true })
        {
            if (pdi.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in files)
                {
                    var pdoc = new PrintDocument { DocumentName = file, PrinterSettings = pdi.PrinterSettings };
                    pdoc.PrintPage += /* PrintPage event handler here */;
                    pdoc.Print();
                }
            }
        }
    }
