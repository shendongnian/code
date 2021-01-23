        private byte[] getHTML(newBidViewModel model)
        {
            string strHtml = ...;
            HtmlToPdfConverter pdfConverter = new HtmlToPdfConverter();
            pdfConverter.CustomWkHtmlArgs = "--page-size Letter";
            var pdfBytes = pdfConverter.GeneratePdf(strHtml);
            return **pdfBytes**;
        }
