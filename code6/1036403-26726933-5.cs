    GlobalConfig gc = new GlobalConfig();
    gc.SetMargins(new Margins(300, 100, 150, 100))
      .SetDocumentTitle("Test document")
      .SetPaperSize(PaperKind.Letter);
    IPechkin pechkin = new SynchronizedPechkin(gc);
    
    ObjectConfig oc = new ObjectConfig();
    oc.SetCreateExternalLinks(false);
    oc.SetFallbackEncoding(Encoding.ASCII);
    oc.SetLoadImages(false);
    oc.Footer.SetCenterText("I'm a footer!");
    oc.Footer.SetLeftText("[page]");
    oc.Header.SetCenterText("I'm a header!");
    
    byte[] result = pechkin.Convert(oc, "<h1>My Website</h1>");
    System.IO.File.WriteAllBytes(@"c:\pechkinTest.pdf", result);
