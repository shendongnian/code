    //open document
    Document document = new Document("input.pdf");
    
    //extract actions
    Page page = document.Pages[1];
    AnnotationSelector selector = new AnnotationSelector(new LinkAnnotation(page, Aspose.Pdf.Rectangle.Trivial));
    page.Accept(selector);
    IList list = selector.Selected;
    
    foreach (LinkAnnotation annotation in list)
    {
    
        int pagenum = ((Aspose.Pdf.InteractiveFeatures.ExplicitDestination)(Aspose.Pdf.InteractiveFeatures.FitExplicitDestination)(annotation.Destination)).PageNumber;
        Console.WriteLine("Page Number: " + pagenum);
    }
