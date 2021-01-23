    var pdfPrint = new PdfPrint("demoCompany", "demoKey");
    string pdfFile = @"c:\test\test.pdf";
    pdfPrint.IsLandscape = true;
    
    int numberOfPages = pdfPrint.GetNumberOfPages(pdfFile);
    var status = pdfPrint.Print(pdfFile);
    if (status == PdfPrint.Status.OK) { 
         // check the result status of the Print method
         // your code here
    }
    // if you have pdf document in byte array that is also supported
    byte[] pdfContent = YourCustomMethodWhichReturnsPdfDocumentAsByteArray();
    status = pdfPrint.Print(pdfFile);
                    
