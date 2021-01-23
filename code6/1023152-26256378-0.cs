            PdfReader pdf = new PdfReader("Test1.pdf");
            File.Delete("C:/Blocks.pdf");
            PdfStamper stp = new PdfStamper(pdf, new FileStream("C:/Blocks.pdf", FileMode.OpenOrCreate));
            
            var canvas = stp.GetOverContent(1);
            PdfPTable table = new PdfPTable(1);
            table.SetTotalWidth(new float[] { 100 });
            Phrase phrase = new Phrase();
            phrase.Hyphenation = new HyphenationAuto("ru", "RU", 2, 2);
            var bf = BaseFont.CreateFont("c:/windows/fonts/arialbd.ttf", "Cp1251", BaseFont.EMBEDDED);
            phrase.Add(new Chunk("О БОЖЕ ТЫ МОЙ НЕУЖЕЛИ РАБОТАЕТ ЕСЛИ РАБОТАЕТ Я БЫЛ БЫ ТАК СЧАСТЛИВ", new Font(bf, 12)));
            PdfPCell cell = new PdfPCell(phrase);
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);
            table.WriteSelectedRows(0, 1, 200, 200, canvas);
            stp.Close();
