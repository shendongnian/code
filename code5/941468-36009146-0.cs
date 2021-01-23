    Document document = new Document();
    Section section = document.AddSection();
    section.PageSetup.PageWidth = Unit.FromMillimeter(100);
    section.PageSetup.PageHeight = Unit.FromMillimeter(10000);
    //add tables etc.
    //note: all my tables are added using document.LastSection.Add(table)
 
    DocumentRenderer renderer = new DocumentRenderer(document);
    renderer.PrepareDocument();
    RenderInfo[] info = renderer.GetRenderInfoFromPage(1);
    int index = info.Length - 1;
    double stop = info[index].LayoutInfo.ContentArea.Y.Millimeter + info[index].LayoutInfo.ContentArea.Height.Millimeter; //add more if you have bottom page margin, borders on the last table etc.
    section.PageSetup.PageHeight = Unit.FromMillimeter(stop);
