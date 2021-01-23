    ObjectConfig oc = new ObjectConfig();
    oc.SetLoadImages(true);
    oc.SetZoomFactor(1.5);
    oc.SetPrintBackground(true);
    oc.SetScreenMediaType(true);
    oc.SetCreateExternalLinks(true);
    oc.Footer.SetLeftText("[page]");
    oc.Footer.SetCenterText("I'm a footer!");
    oc.Header.SetCenterText("TEST HEADER TEST1");
    
    var result = pechkin.Convert(oc, "<h1>My Website</h1>");
    System.IO.File.WriteAllBytes(@"c:\pechkinTest.pdf", result);
