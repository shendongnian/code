    // I don't know anything about ITextSharp
    // I've modified your code to not create the file until after encryption
    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
    {
        string filepath = saveFileDialog1.FileName; // Store the file name
        // Export to Stream
        var ms = crd.ExportToStream(ExportFormatType.PortableDocFormat);
        var doc = new Document(PageSize.A4);
        ms.Position = 0; // 0 the stream
        // Create a new file stream
        using (var fs = new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            PdfReader reader = new PdfReader(ms); // Load pdf stream created earlier
            // Encrypt pdf to file stream
            PdfEncryptor.Encrypt(reader, fs, PdfWriter.STRENGTH128BITS, "pass", "pass", PdfWriter.AllowScreenReaders);
            // job done?
        }
    }
