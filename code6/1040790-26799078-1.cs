    class CellBackground : IPdfPCellEvent {
      public void CellLayout(
        PdfPCell cell, Rectangle rect, PdfContentByte[] canvas
    ) {
        PdfContentByte cb = canvas[PdfPTable.BACKGROUNDCANVAS];
        cb.RoundRectangle(
          rect.Left + 1.5f, 
          rect.Bottom + 1.5f, 
          rect.Width - 3,
          rect.Height - 3, 4
        );
        cb.SetCMYKColorFill(0x00, 0x00, 0x00, 0x00);
        cb.Fill();
      }
    }
