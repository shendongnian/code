        [HttpPost]
        public FileStreamResult Certificate(MyModel model)
        {
            Stream fileStream = GeneratePDF(model);
            HttpContext.Response.AddHeader("content-disposition", "inline; filename=Certificate.pdf");
            var fileStreamResult = new FileStreamResult(fileStream, "application/pdf");
            return fileStreamResult;
        }
        public Stream GeneratePDF(HomeViewModel model)
        {
    
    var rect = new Rectangle(288f, 144f);
    var doc = new Document(rect, 0, 0, 0, 0);
    BaseFont bfArialNarrow = BaseFont.CreateFont(Server.MapPath("../Content/fonts/ARIALN.ttf"), BaseFont.CP1252, BaseFont.EMBEDDED);
    //Full Background Image (Includes watermark)
    Image fullBackground = null;
    fullBackground = Image.GetInstance(Server.MapPath("../Content/images/Certificate/Cert1.jpg"));
    doc.SetPageSize(PageSize.LETTER.Rotate());
    MemoryStream memoryStream = new MemoryStream();
    PdfWriter pdfWriter = PdfWriter.GetInstance(doc, memoryStream);
    doc.Open();
    //Full Background Image
    fullBackground.Alignment = Image.UNDERLYING | Image.ALIGN_CENTER | Image.ALIGN_MIDDLE;
    doc.Add(fullBackground);
    Font myFont = new Font(bfArialNarrow, 57);
    var myParagraph = new Paragraph("Some text here.", myFont);
    doc.Add(myParagraph);
    pdfWriter.CloseStream = false;
    doc.Close();
    memoryStream.Position = 0;
            
    return memoryStream;
    }
