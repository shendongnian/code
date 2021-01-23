    private void DrawLines(Document pdfDoc, PdfContentByte cb) {
        cb.SaveState();
        cb.SetColorStroke(GrayColor.GRAYBLACK);
        cb.MoveTo(0, 562);
        cb.LineTo(pdfDoc.PageSize.Width, 562);
        cb.MoveTo(0, 561);
        cb.LineTo(pdfDoc.PageSize.Width, 561);
        cb.Stroke();
        cb.RestoreState();
    }
