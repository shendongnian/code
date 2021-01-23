        public void drawVerticalText2()
        {
            PdfPTable table = new PdfPTable(4);
            float[] widths = new float[] { 1.25f, 1.55f, 0.35f, 0.35f };
            table.SetWidths(widths);
            PdfPCell horizontalCell = new PdfPCell(new Phrase("I'm horizontal"));
            horizontalCell.Border = BORDERS.BOX;
            horizontalCell.HorizontalAlignment = 1;
            table.AddCell(horizontalCell);
            PdfPCell horizontalMirroredCell = new PdfPCell(new Phrase("I'm horizontal mirrored"));
            horizontalMirroredCell.Border = BORDERS.BOX;
            horizontalMirroredCell.HorizontalAlignment = 1;
            horizontalMirroredCell.Rotation = 180;
            table.AddCell(horizontalMirroredCell);
            PdfPCell verticalCell = new PdfPCell(new Phrase("I'm vertical"));
            verticalCell.Border = BORDERS.BOX;
            verticalCell.HorizontalAlignment = 1;
            verticalCell.Rotation = 90;
            table.AddCell(verticalCell);
            PdfPCell verticalMirroredCell = new PdfPCell(new Phrase("I'm vertical  mirrored"));
            verticalMirroredCell.Border = BORDERS.BOX;
            verticalMirroredCell.HorizontalAlignment = 1;
            verticalMirroredCell.Rotation = -90;
            table.AddCell(verticalMirroredCell);
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;
            document.Add(table);
            document.Close();
        }
