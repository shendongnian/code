    //Create an instance of our helper class
    var imgList = new MyImageRenderListener();
    //Parse the PDF and inspect each image
    using (var reader = new PdfReader(testFile)) {
        var proc = new iTextSharp.text.pdf.parser.PdfReaderContentParser(reader);
        for (var i = 1; i <= reader.NumberOfPages; i++) {
            //Get the page object itself
            var p = reader.GetPageN(i);
            //Get the page units. Per spec, page units are expressed as multiples of 1/72 of an inch with a default of 72.
            var pageUnits = (p.Contains(PdfName.USERUNIT) ? p.GetAsNumber(PdfName.USERUNIT).FloatValue : 72);
                    
            //Set the page number so we can find it later
            imgList.CurrentPage = i;
            imgList.CurrentPageUnits = pageUnits;
            //Process the page
            proc.ProcessContent(i, imgList);
        }
    }
    //Dump out some information
    foreach (var p in imgList.Pages) {
        foreach (var i in p.Value) {
            Console.WriteLine(String.Format("Image PPI is {0}x{1}", i.ImgWidthScale * i.PageUnits, i.ImgHeightScale * i.PageUnits));
        }
    }
