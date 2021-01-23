    WebSupergoo.ABCpdf9.Doc firstDoc = new WebSupergoo.ABCpdf9.Doc();
    WebSupergoo.ABCpdf9.Doc secondDoc = new WebSupergoo.ABCpdf9.Doc();
    
    firstDoc.Read(@"C:\pdf1.pdf");
    
    for (int i = 1; i <= firstDoc.PageCount; i++)
    {
        firstDoc.PageNumber = i;
        secondDoc.MediaBox.String = firstDoc.MediaBox.String;
        secondDoc.Page = secondDoc.AddPage();
    
        using (Bitmap bm = firstDoc.Rendering.GetBitmap())
        {
            secondDoc.AddImageBitmap(bm, false);
        }
    }
    
    secondDoc.Save(@"c:\pdf2.pdf");
