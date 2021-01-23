    using C1.Phone.Pdf;
    using C1.Phone.PdfViewer;
    C1PdfDocument pdf = new C1PdfDocument(PaperKind.PrcEnvelopeNumber3Rotated);
    pdf.Landscape = true;
    var rc = new System.Windows.Rect(20,30,300,200);
    pdf.DrawImage(wbitmp, rc);
    var fillingName = "Test.pdf";
    var gettingFile = IsolatedStorageFile.GetUserStoreForApplication();
    using (var loadingFinalStream = gettingFile.CreateFile(fillingName))
    {
       pdf.Save(loadingFinalStream);
    }
