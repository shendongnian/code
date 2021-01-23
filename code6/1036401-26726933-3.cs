    var document = new HtmlToPdfDocument
    {
        GlobalSettings =
        {
            ProduceOutline = true,
            DocumentTitle = "My Website",
            PaperSize = PaperKind.A4,
            Margins =
            {
                All = 1.375,
                Unit = Unit.Centimeters
            }
        },
        Objects = {
            new ObjectSettings
            {
                HtmlText = "<h1>My Website</h1>",
                HeaderSettings = new HeaderSettings{CenterText = "I'm a header!"},
                FooterSettings = new FooterSettings{CenterText = "I'm a footer!", LeftText = "[page]"}
            }
        }
    };
    
    IPechkin converter = Factory.Create();
    byte[] result = converter.Convert(document);
    System.IO.File.WriteAllBytes(@"c:\tuespechkinTest.pdf", result);
