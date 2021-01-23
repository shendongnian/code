    private class MyEvent : IPdfPCellEvent {
        string number;
        public MyEvent(string number) {
             this.number = number;
        }
        public void CellLayout(PdfPCell cell, Rectangle position, PdfContentByte[] canvases) {
            ColumnText.ShowTextAligned(
                canvases[PdfPTable.TEXTCANVAS],
                Element.ALIGN_LEFT,
                new Phrase(number),
                position.Left + 2, position.Top - 16, 0);
        }
    }
