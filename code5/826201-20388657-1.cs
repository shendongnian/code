    public void RenderImage(iTextSharp.text.pdf.parser.ImageRenderInfo renderInfo)
    {
        iTextSharp.text.pdf.parser.PdfImageObject image = renderInfo.GetImage();
        if (image == null) return;
        ImageNames.Add(renderInfo.GetRef().Number);
    }
