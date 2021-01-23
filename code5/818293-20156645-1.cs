    using (MemoryStream ms = new MemoryStream())
    {
        using (Document document = new Document(PageSize.LETTER))
        {
            using (PdfWriter writer = PdfWriter.GetInstance(document, ms))
            {
                document.Open();
                    
                //document properties
                float margin = 36f;
                document.SetMargins(margin, margin, margin, margin);
                document.NewPage();
                //description
                customFont = FontFactory.GetFont("Helvetica", 10);
                Phrase description = new Phrase(itemDescription, customFont);
                table = new PdfPTable(1);
                table.WidthPercentage = 100;
                cell = new PdfPCell(description);
                cell.Border = 0;
                float maxHeight = 98f;
                if (descriptionTableHeight > maxHeight)
                    cell.FixedHeight = maxHeight;
                table.AddCell(cell);
                document.Add(table);
            }
        }
    }
