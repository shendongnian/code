    public static void MergePages()
    {
        PdfReader reader = new PdfReader(@"C:\Users\cmilne\Desktop\AA0081913.pdf");//Original PDF containing page breaks. 
            
        int pages = reader.NumberOfPages;
        float postProcessPageHeight = 0;
        float postProcessPageWidth = 0;
        for (int p = 1; p <= bill.PageCount; p++)
        {
            var size = bill.PdfReader.GetPageSize(p);
            postProcessPageHeight += (size.Height);
            if (size.Width > postProcessPageWidth)
                postProcessPageWidth = (size.Width);
        }
        var rect = new Rectangle(postProcessPageWidth, postProcessPageHeight);
        using (Document document = new Document(rect, 0, 0, 0, 0)) 
        { 
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
    }
