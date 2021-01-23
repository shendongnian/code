    public PdfPTable GetTable(List<hsp_Narudzbe_IzdavanjeFakture4_Result> proizvodi)
        {
            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 100F;
            table.DefaultCell.UseAscender = true;
            table.DefaultCell.UseDescender = true;
            Font f = new Font(Font.FontFamily.HELVETICA, 13);
            f.Color = BaseColor.WHITE;
            PdfPCell cell = new PdfPCell(new Phrase("Stavke narudžbe: ", f));
            cell.BackgroundColor = BaseColor.BLACK;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Colspan = 5;
            table.AddCell(cell);
            for (int i = 0; i < 2; i++)
            {
                table.AddCell(new PdfPCell(new Phrase("Redni broj"))
                    {
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        BackgroundColor = BaseColor.LIGHT_GRAY
                    });
                table.AddCell(new PdfPCell(new Phrase("Proizvod"))
                {
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    BackgroundColor = BaseColor.LIGHT_GRAY
                });
                table.AddCell(new PdfPCell(new Phrase("Cijena"))
                {
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    BackgroundColor = BaseColor.LIGHT_GRAY
                });
                table.AddCell(new PdfPCell(new Phrase("Šifra"))
                {
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    BackgroundColor = BaseColor.LIGHT_GRAY
                });
                table.AddCell(new PdfPCell(new Phrase("Kolicina"))
                {
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    BackgroundColor = BaseColor.LIGHT_GRAY
                });
            }
            table.DefaultCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.HeaderRows = 3;
            table.FooterRows = 1;
            int broj = 0;
            table.DeleteLastRow();
            foreach (hsp_Narudzbe_IzdavanjeFakture4_Result p in proizvodi)
            {
                broj++;
                table.AddCell(new PdfPCell(new Phrase(broj.ToString()))
                {
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_CENTER
                 
                });
                table.AddCell(new PdfPCell(new Phrase(p.Naziv))
                {
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                table.AddCell(new PdfPCell(new Phrase(p.Cijena))
                {
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                table.AddCell(new PdfPCell(new Phrase(p.Sifra))
                {
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                table.AddCell(new PdfPCell(new Phrase(p.Kolicina.ToString()))
                {
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
            }
        
            
           
            return table;
        }
