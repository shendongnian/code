    using (var memoryStream = new MemoryStream())
    {
        using (var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate()))
        {
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            writer.CloseStream = false;
            // Write PDF here.
        }
        byte[] docArray = memoryStream.ToArray();
    }
