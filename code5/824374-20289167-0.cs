    public Stream Generate(GiftModel model)
    {
        //We'll dump our PDF into these when done
        Byte[] bytes;
        using (var ms = new MemoryStream())
        {
            using (var doc = new Document())
            {
                using (var writer = PdfWriter.GetInstance(doc, ms))
                {
                    doc.Open();
                    doc.Add(new Paragraph("Hello"));
                    doc.Close();
                }
            }
            //Finalize the contents of the stream into an array
            bytes = ms.ToArray();
        }
        //Return a new stream wrapped around our array
        return new MemoryStream(bytes);
    }
