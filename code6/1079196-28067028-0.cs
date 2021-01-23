    class GenericTags : PdfPageEventHelper {
      public override void OnGenericTag(
        PdfWriter writer, Document pdfDocument, Rectangle rect, String text) {
        PdfContentByte content = writer.DirectContentUnder, rect);
        content.SaveState();
        content.SetRGBColorFill(0x00, 0x00, 0xFF);
        content.Ellipse(
          rect.Left - 3f, rect.Bottom - 5f,
          rect.Right + 3f, rect.Top + 3f
        );
        content.Fill();
        content.RestoreState();
      }
    }
