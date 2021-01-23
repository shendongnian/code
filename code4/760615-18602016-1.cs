    static void Main(string[] args)
        {
            PdfReader reader = new PdfReader(@"C:\Users\cmilne\Desktop\AA0081913.pdf");//Original PDF containing page breaks. 
            Rectangle rectangle1 = reader.GetPageSize(1);
            int pages = reader.NumberOfPages;
            Rectangle rect = new Rectangle(rectangle1.Width, (rectangle1.Height * pages));
            Document document = new Document(rect, 0, 0, 0, 0);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(@"C:\Users\cmilne\Desktop\AA0081913_NEW.pdf", FileMode.Create)); //Declare location\name of new PDF not containing page breaks.
            document.Open();
            PdfImportedPage page;
            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;
            for (int i = 1; i <= pages; i++)
            {
                page = writer.GetImportedPage(reader, i);
                table.AddCell(iTextSharp.text.Image.GetInstance(page));
            }
            document.Add(table);
            document.Close();
        }
