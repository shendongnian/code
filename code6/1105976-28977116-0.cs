    using (var zipMemorystream = new MemoryStream())
    {
        using (var archive = new ZipArchive(zipMemorystream, ZipArchiveMode.Create, true))
        {
            for (int i = 0; i < 10; i++)
            {
                var file = archive.CreateEntry(string.Format("Test{0}.pdf", i), CompressionLevel.Optimal);
                using (Stream stream = file.Open( ))
                {
                    using( var document = new Document(PageSize.A4, 25, 25, 30, 30) )
                    {
                        using( var writer = PdfWriter.GetInstance(document, stream))
                        {
                            document.Open();
                            //
                            var table = new PdfPTable(7);
                            var fdefault = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, BaseColor.DARK_GRAY);
                            table.AddCell(new Paragraph("Container", fdefault));
                            table.AddCell(new Paragraph("Code", fdefault));
                            table.AddCell(new Paragraph("ITEM", fdefault));
                            table.AddCell(new Paragraph("Reference", fdefault));
                            table.AddCell(new Paragraph("Description", fdefault));
                            table.AddCell(new Paragraph("Size", fdefault));
                            table.AddCell(new Paragraph("Quantity", fdefault));
                            document.Add(table);
                            document.Close();
                        }
                    }
                }
            }
        }
        string zip = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ZipFile.zip");
        using (var fileStream = new FileStream(zip, FileMode.Create))
        {
            zipMemorystream.Seek(0, SeekOrigin.Begin);
            zipMemorystream.CopyTo(fileStream);
        }
    }
