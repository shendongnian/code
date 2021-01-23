    //Create an instance of our helper class
    var imgList = new MyImageRenderListener();
    //Parse the PDF and inspect each image
    using (var reader = new PdfReader(testFile)) {
        var proc = new iTextSharp.text.pdf.parser.PdfReaderContentParser(reader);
        for (var i = 1; i <= reader.NumberOfPages; i++) {
            //Set the page number so we can find it later
            imgList.CurrentPage = i;
            //Process the page
            proc.ProcessContent(i, imgList);
        }
    }
    //Dump out some information
    foreach (var p in imgList.Pages) {
        foreach (var i in p.Value) {
            Console.WriteLine(String.Format("Image PPI is {0}x{1}", i.ImgWidthScale * 72, i.ImgHeightScale * 72));
        }
    }
