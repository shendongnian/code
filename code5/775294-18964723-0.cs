        public ActionResult Index()
        {
            return View();
        }
        public FileStreamResult CreatePDF()
        {
            Stream fileStream = GeneratePDF();
            HttpContext.Response.AddHeader("content-disposition", "inline; filename=MyPDF.pdf");
            var fileStreamResult = new FileStreamResult(fileStream, "application/pdf");
            return fileStreamResult;
        }
        private Stream GeneratePDF()
        {
            var rect = new Rectangle(288f, 144f);
            var document = new Document(rect, 10, 10, 10, 10);
            document.SetPageSize(PageSize.LETTER.Rotate());
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, memoryStream);
            document.Open();
            ////////////////////////
            //Place Image in a Specific (Absolute) Location
            ////////////////////////
            Image myImage = Image.GetInstance(Server.MapPath("../Content/BI_logo_0709.png"));
            myImage.SetAbsolutePosition(45, 45);
            //[dpi of page]/[dpi of image]*100=[scale percent]
            //72 / 200 * 100 = 36%
            //myImage.ScalePercent(36f);
            myImage.ScalePercent(36f);
            document.Add(myImage);
            ////////////////////////
            //Place Text in a Specific (Absolute) Location
            ////////////////////////
            //Create a table to hold everything
            PdfPTable myTable = new PdfPTable(1);
            myTable.TotalWidth = 200f;
            myTable.LockedWidth = true;
            //Create a paragraph with the text to be placed
            BaseFont bfArialNarrow = BaseFont.CreateFont(Server.MapPath("../Content/ARIALN.ttf"), BaseFont.CP1252, BaseFont.EMBEDDED);
            var basicSmaller = new Font(bfArialNarrow, 10);
            var myString = "Hello World!" +
                                Environment.NewLine +
                                "Here is more text." +
                                Environment.NewLine +
                                "Have fun programming!";
            var myParagraph = new Paragraph(myString, basicSmaller);
            //Create a cell to hold the text aka paragraph
            PdfPCell myCell = new PdfPCell(myParagraph);
            myCell.Border = 0;
            //Add the cell to the table
            myTable.AddCell(myCell);
            //Add the table to the document in a specific (absolute) location
            myTable.WriteSelectedRows(0, -1, 550, 80, pdfWriter.DirectContent);
  
            pdfWriter.CloseStream = false;
            document.Close();
            memoryStream.Position = 0;
            return memoryStream;
        }
