     public class PageEventHelper : PdfPageEventHelper
     {
        PdfContentByte cb;
        PdfTemplate template;
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            cb = writer.DirectContent;
            template = cb.CreateTemplate(width, height);
        }
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            int pageN = writer.PageNumber;
            String text = "Page " + pageN.ToString() + " of ";
            Rectangle pageSize = document.PageSize;
            cb.BeginText();
            cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 12F);
            cb.SetTextMatrix(Width, Height);
            cb.ShowText(text);
            cb.EndText();
            //Add the template to each page so we can add the total page number later
            cb.AddTemplate(template, Width, Height);
        }
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            template.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 12F);
            template.BeginText();
            template.SetTextMatrix(0, 0);
            //Add the final page number.
            template.ShowText("" + (writer.PageNumber - 1));
            //This will write the number on all templates on all pages
            template.EndText();
        }
    }
