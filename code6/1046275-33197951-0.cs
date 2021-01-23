    using System;
    using System.IO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
     
    namespace iTextSharpTests
    {
       class Program
       {
           static void Main(string[] args)
           {
               using (var pdfDoc = new Document(PageSize.A4))
               {
                   var pdfWriter = PdfWriter.GetInstance(pdfDoc, new FileStream("Test.pdf", FileMode.Create));
                   pdfDoc.Open();
     
                   var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\tahoma.ttf";
                   var baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                   var tahomaFont = new Font(baseFont, 10, Font.NORMAL, BaseColor.BLACK);
     
                   ColumnText ct = new ColumnText(pdfWriter.DirectContent);
                   ct.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                   ct.SetSimpleColumn(100, 100, 500, 800, 24, Element.ALIGN_RIGHT);
     
                   var chunk = new Chunk("تست", tahomaFont);
     
                   ct.AddElement(chunk);
                   ct.Go();
               }
           }
       }
    }
