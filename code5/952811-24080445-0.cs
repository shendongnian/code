    using (PdfStamper stamper = new PdfStamper(reader, ms))
    {
       PdfContentByte canvas = stamper.GetOverContent(1);
       String message = String.Format("mutli\nline\text");
    }
    PdfGState gState = new PdfGState();
    gState.FillOpacity = 0.3f;
    canvas.SetGState(gState);
    using (StringReader stringReader = new StringReader(message))
    {
       string line;
       float y = size.Height / 2 + 200;
       while ((line = stringReader.ReadLine()) != null)
       {
          Phrase p = new Phrase(line,FontFactory.GetFont(FontFactory.HELVETICA, 35));
             ColumnText.ShowTextAligned(canvas, Element.ALIGN_CENTER, p, 300, y, 30);
          y = y - 70;
       }
    }
}
