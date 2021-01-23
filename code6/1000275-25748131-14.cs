    using System;
    using System.IO;
    using System.Drawing.Imaging;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using Svg;
    // ...
    public static MemoryStream PngFromSvg(string svgXml)
    {
        MemoryStream pngStream = new MemoryStream();
        if (!string.IsNullOrWhiteSpace(svgXml))
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(svgXml);
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                SvgDocument svgDocument = SvgDocument.Open(stream);
                System.Drawing.Bitmap bitmap = svgDocument.Draw();
                bitmap.Save(pngStream, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
    public static MemoryStream GeneratePdf(MemoryStream pngStream)
    {
        MemoryStream pdfStream = new MemoryStream();
        using (Document document = new Document(PageSize.A4, 20, 20, 20, 20))
        {
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, pdfStream);
            // ...
            Image chartImage = Image.GetInstance(System.Drawing.Image.FromStream(pngStream), ImageFormat.Png);
            PdfPCell chartCell = new PdfPCell(chartImage, true);
            chartCell.Border = Rectangle.NO_BORDER;
            //...
            document.Close();
            pdfWriter.Close();
        }
        return pdfStream;
    }
    public class SvgData
    {
        public string svgXml { get; set; }
    }
    public class PdfData
    {
        public string pdfId { get; set; }
    }
    public JsonResult GeneratePdf(SvgData data)
    {
        byte[] pdfBytes = GeneratePdf(PngFromSvg(data.svgXml)).ToArray();
        // ...
        // Either:
        //  :: Store PDF in database as blob and return unique ID
        //  :: Store as file and return path to file
        return Json(new PdfData{pdfId = pdf.id}, JsonRequestBehavior.AllowGet);
    }
    public ActionResult GetPdf(Int64 pdfId)
    {   
        // retrieve pdf from database
        byte[] pdfBytes = pdf.raw;
        return File(pdfBytes, "application/pdf");
    }
