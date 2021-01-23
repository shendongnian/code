    var complianceFiles = System.IO.Directory.EnumerateFiles(
        complianceDocumentPath,
        salesOrder.CustomerNumber + "*.pdf", 
        System.IO.SearchOption.TopDirectoryOnly
        ).Where(path => Path.GetFileName(path)
            .TakeWhile(Char.IsDigit).Count() == 
                Math.Ceiling(Math.Log10(salesOrder.CustomerNumber)));
