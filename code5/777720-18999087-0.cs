    protected internal class MyEventHandler : IEventHandler {
        public virtual void HandleEvent(Event @event) {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
            PdfDocument pdfDoc = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();
            int pageNumber = pdfDoc.GetPageNumber(page);
            Rectangle pageSize = page.GetPageSize();
            PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
            //Add header
            pdfCanvas.BeginText()
                .SetFontAndSize(C03E03_UFO.helvetica, 9)
                .MoveText(pageSize.GetWidth() / 2 - 60, pageSize.GetTop() - 20)
                .ShowText("THE TRUTH IS OUT THERE")
                .MoveText(60, -pageSize.GetTop() + 30)
                .ShowText(pageNumber.ToString())
                .EndText();
            pdfCanvas.release();
        }
    }
